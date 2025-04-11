using Microsoft.AspNetCore.Mvc;
using Crayonlab.Services;
using Crayonlab.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Crayonlab.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationService;

        public ShopController(ApplicationDbContext context, IAuthorizationService authorizationService)
        {
            _context = context;
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> Index()
        {
            var isAdmin = User.Identity.IsAuthenticated &&
                         (await _authorizationService.AuthorizeAsync(User, "Admin")).Succeeded;

            var model = new ShopViewModel
            {
                ShirtTypes = await _context.ShirtTypes.ToListAsync(),
                DesignsByType = (await _context.ShirtDesigns
                    .Include(d => d.ShirtType)
                    .Where(d => isAdmin || d.IsActive)
                    .ToListAsync())
                    .GroupBy(d => d.ShirtTypeId)
                    .ToDictionary(g => g.Key, g => g.ToList()),
                IsAdmin = isAdmin
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UploadDesign(
            IFormFile frontDesign,
            IFormFile backDesign,
            IFormFile shortsDesign,
            int shirtTypeId,
            string name,
            decimal menXSPrice,
            decimal menSPrice,
            decimal menMPrice,
            decimal menLPrice,
            decimal menXLPrice,
            decimal menXXLPrice,
            decimal womenXSPrice,
            decimal womenSPrice,
            decimal womenMPrice,
            decimal womenLPrice,
            decimal womenXLPrice,
            decimal womenXXLPrice)
        {
            if (frontDesign == null || frontDesign.Length == 0)
            {
                return Json(new { success = false, message = "Front design is required." });
            }

            try
            {
                var shirtType = await _context.ShirtTypes.FindAsync(shirtTypeId);
                if (shirtType == null)
                {
                    return Json(new { success = false, message = "Invalid shirt type." });
                }

                var design = new ShirtDesign
                {
                    ShirtTypeId = shirtTypeId,
                    Name = name,
                    FrontDesign = await SaveFile(frontDesign), // Only filename
                    BackDesign = backDesign != null ? await SaveFile(backDesign) : null, // Only filename
                    ShortsDesign = shortsDesign != null ? await SaveFile(shortsDesign) : string.Empty, // Only filename
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true,
                    MenXSPrice = menXSPrice,
                    MenSPrice = menSPrice,
                    MenMPrice = menMPrice,
                    MenLPrice = menLPrice,
                    MenXLPrice = menXLPrice,
                    MenXXLPrice = menXXLPrice,
                    WomenXSPrice = womenXSPrice,
                    WomenSPrice = womenSPrice,
                    WomenMPrice = womenMPrice,
                    WomenLPrice = womenLPrice,
                    WomenXLPrice = womenXLPrice,
                    WomenXXLPrice = womenXXLPrice
                };

                _context.ShirtDesigns.Add(design);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            catch (DbUpdateException dbEx)
            {
                // Log the inner exception
                var innerException = dbEx.InnerException?.Message ?? "No inner exception.";
                return Json(new { success = false, message = $"Database update error: {innerException}" });
            }
            catch (Exception ex)
            {
                // Log the general exception
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }




        private async Task<string> SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is not valid.");

            // Get the root path of the application
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Content", "uploads");

            // Create the uploads directory if it doesn't exist
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate a unique filename to avoid conflicts
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName; // Return only the filename
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> ToggleAvailability(int id, bool isActive)
        {
            try
            {
                var design = await _context.ShirtDesigns.FindAsync(id);
                if (design == null)
                {
                    return Json(new { success = false, message = "Design not found." });
                }

                design.IsActive = isActive;
                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Availability updated successfully.",
                    newStatus = design.IsActive
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An error occurred on the server.",
                    error = ex.Message
                });
            }
        }


    }
}

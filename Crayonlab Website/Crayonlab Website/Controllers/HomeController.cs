using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Crayonlab.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Crayonlab.Services;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _env;

    public HomeController(ApplicationDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    // GET: Home
    public IActionResult Index()
    {
        var partners = _context.Partners.ToList();
        var viewModel = new ShopViewModel
        {
            Partners = partners
        };
        return View(viewModel);
    }

    // POST: Upload Partner
    [HttpPost]
    public async Task<IActionResult> UploadPartner(IFormFile image, string description)
    {
        try
        {
            if (image == null || image.Length == 0)
                return Json(new { success = false, message = "Please select an image." });

            // Validate image
            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var fileExtension = Path.GetExtension(image.FileName).ToLower();

            if (!validExtensions.Contains(fileExtension))
                return Json(new { success = false, message = "Only JPG, PNG, or GIF images are allowed." });

            if (image.Length > 5 * 1024 * 1024) // 5MB
                return Json(new { success = false, message = "Image size must be less than 5MB." });

            // Save image
            var uploadsPath = Path.Combine(_env.WebRootPath, "Content", "assets");
            Directory.CreateDirectory(uploadsPath);

            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            // Save to database
            var partner = new Partners
            {
                Image = $"/Content/assets/{fileName}",
                Description = description
            };

            _context.Partners.Add(partner);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                id = partner.Id,
                imageUrl = partner.Image,
                description = partner.Description
            });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeletePartner([FromBody] DeletePartnerRequest request)
    {
        try
        {
            var partner = await _context.Partners.FindAsync(request.Id);
            if (partner == null)
                return Json(new { success = false, message = "Partner not found." });

            // Delete image file
            if (!string.IsNullOrEmpty(partner.Image))
            {
                var filePath = Path.Combine(_env.WebRootPath, partner.Image.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            // Remove from database
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    public class DeletePartnerRequest
    {
        public int Id { get; set; }
    }


    // Validate the uploaded image
    private IActionResult ValidateImage(IFormFile image)
    {
        var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(image.FileName).ToLower();

        if (!validExtensions.Contains(fileExtension))
        {
            return Json(new { success = false, message = "Only JPG, PNG, or GIF images are allowed." });
        }

        if (image.Length > 5 * 1024 * 1024) // 5MB
        {
            return Json(new { success = false, message = "Image size must be less than 5MB." });
        }

        return null;
    }

    // Save the uploaded image to the file system
    private async Task<string> SaveImageToFileSystem(IFormFile image)
    {
        var uploadsPath = Path.Combine(_env.WebRootPath, "Content", "assets");
        Directory.CreateDirectory(uploadsPath); // Ensure the directory exists

        var fileExtension = Path.GetExtension(image.FileName).ToLower();
        var fileName = Guid.NewGuid().ToString() + fileExtension;
        var filePath = Path.Combine(uploadsPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        return fileName;
    }
}

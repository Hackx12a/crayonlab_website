using Microsoft.AspNetCore.Mvc;
using Crayonlab.Services;
using Crayonlab.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace Crayonlab.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment env;

        public ShopController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            var designs = context.Designs.ToList();
            var jerseys = context.BasketballJerseys.ToList();
            var longsleeves = context.Longsleeves.ToList();
            var soccerjerseys = context.Soccerjerseys.ToList();

            var viewModel = new ShopViewModel
            {
                Designs = designs,
                BasketballJerseys = jerseys,
                Longsleeves = longsleeves,
                Soccerjerseys = soccerjerseys
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadDesign(
            String Name,
            IFormFile frontDesign,
            IFormFile backDesign,
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
            decimal womenXXLPrice,
            IFormFile shortDesign = null)
        {
            if (!IsValidFileUpload(frontDesign, backDesign))
            {
                ViewData["ErrorMessage"] = "Both front and back designs must be selected for upload.";
                return View("Error");
            }

            if (
                menXSPrice <= 0 ||
                menSPrice <= 0 ||
                menMPrice <= 0 ||
                menLPrice <= 0 ||
                menXLPrice <= 0 ||
                menXXLPrice <= 0 ||
                womenXSPrice <= 0 ||
                womenSPrice <= 0 ||
                womenMPrice <= 0 ||
                womenLPrice <= 0 ||
                womenXLPrice <= 0 ||
                womenXXLPrice <= 0)
            {
              
                

            }

            try
            {
                var uniqueFileNames = await SaveUploadedFiles(frontDesign, backDesign, shortDesign);
                var design = new Designs
                {
                    FrontDesign = uniqueFileNames.Item1,
                    BackDesign = uniqueFileNames.Item2,
                    ShortsDesign = uniqueFileNames.Item3 ?? string.Empty,
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
                    WomenXXLPrice = womenXXLPrice,
                    Name = Name
                };

                context.Designs.Add(design);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadBasketballJersey(
            String Name,
            IFormFile frontDesign,
            IFormFile backDesign,
            decimal price,
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
            decimal womenXXLPrice,
            IFormFile shortDesign = null)
        {
            if (!IsValidFileUpload(frontDesign, backDesign))
            {
                ViewData["ErrorMessage"] = "Both front and back designs must be selected for upload.";
                return View("Error");
            }
            if (
                menXSPrice <= 0 ||
                menSPrice <= 0 ||
                menMPrice <= 0 ||
                menLPrice <= 0 ||
                menXLPrice <= 0 ||
                menXXLPrice <= 0 ||
                womenXSPrice <= 0 ||
                womenSPrice <= 0 ||
                womenMPrice <= 0 ||
                womenLPrice <= 0 ||
                womenXLPrice <= 0 ||
                womenXXLPrice <= 0)
            {
                ViewData["ErrorMessage"] = "All prices must be positive numbers.";
                return View("Error");
            }

            try
            {
                var uniqueFileNames = await SaveUploadedFiles(frontDesign, backDesign, shortDesign);
                var jersey = new BasketballJersey
                {
                    FrontDesign = uniqueFileNames.Item1,
                    BackDesign = uniqueFileNames.Item2,
                    ShortsDesign = uniqueFileNames.Item3 ?? string.Empty,
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
                    WomenXXLPrice = womenXXLPrice,
                    Name = Name
                };

                context.BasketballJerseys.Add(jersey);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadLongsleeve(
            String Name,
            IFormFile frontDesign,
            IFormFile backDesign,
            decimal price,
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
            decimal womenXXLPrice,
            IFormFile shortDesign = null)
        {
            if (!IsValidFileUpload(frontDesign, backDesign))
            {
                ViewData["ErrorMessage"] = "Both front and back designs must be selected for upload.";
                return View("Error");
            }

            if (
                menXSPrice <= 0 ||
                menSPrice <= 0 ||
                menMPrice <= 0 ||
                menLPrice <= 0 ||
                menXLPrice <= 0 ||
                menXXLPrice <= 0 ||
                womenXSPrice <= 0 ||
                womenSPrice <= 0 ||
                womenMPrice <= 0 ||
                womenLPrice <= 0 ||
                womenXLPrice <= 0 ||
                womenXXLPrice <= 0)
            {
                ViewData["ErrorMessage"] = "All prices must be positive numbers.";
                return View("Error");
            }

            try
            {
                var uniqueFileNames = await SaveUploadedFiles(frontDesign, backDesign, shortDesign);
                var longsleeve = new Longsleeve
                {
                    FrontDesign = uniqueFileNames.Item1,
                    BackDesign = uniqueFileNames.Item2,
                    ShortsDesign = uniqueFileNames.Item3 ?? string.Empty,
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
                    WomenXXLPrice = womenXXLPrice,
                    Name = Name
                };

                context.Longsleeves.Add(longsleeve);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadSoccerJersey(
            String Name,
            IFormFile frontDesign,
            IFormFile backDesign,
            decimal price,
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
            decimal womenXXLPrice,
            IFormFile shortDesign = null)
        {
            if (!IsValidFileUpload(frontDesign, backDesign))
            {
                ViewData["ErrorMessage"] = "Both front and back designs must be selected for upload.";
                return View("Error");
            }

            if (
                menXSPrice <= 0 ||
                menSPrice <= 0 ||
                menMPrice <= 0 ||
                menLPrice <= 0 ||
                menXLPrice <= 0 ||
                menXXLPrice <= 0 ||
                womenXSPrice <= 0 ||
                womenSPrice <= 0 ||
                womenMPrice <= 0 ||
                womenLPrice <= 0 ||
                womenXLPrice <= 0 ||
                womenXXLPrice <= 0)
            {
                ViewData["ErrorMessage"] = "All prices must be positive numbers.";
                return View("Error");
            }

            try
            {
                var uniqueFileNames = await SaveUploadedFiles(frontDesign, backDesign, shortDesign);
                var soccerjersey = new Soccerjersey
                {
                    FrontDesign = uniqueFileNames.Item1,
                    BackDesign = uniqueFileNames.Item2,
                    ShortsDesign = uniqueFileNames.Item3 ?? string.Empty,
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
                    WomenXXLPrice = womenXXLPrice,
                    Name = Name
                };

                context.Soccerjerseys.Add(soccerjersey);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDesign(int id)
        {
            var design = await context.Designs.FindAsync(id);
            if (design == null)
            {
                return NotFound();
            }

            return await DeleteDesignFiles(design);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBasketballJersey(int id)
        {
            var jersey = await context.BasketballJerseys.FindAsync(id);
            if (jersey == null)
            {
                return NotFound();
            }

            return await DeleteDesignFiles(jersey);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLongsleeve(int id)
        {
            var longsleeve = await context.Longsleeves.FindAsync(id);
            if (longsleeve == null)
            {
                return NotFound();
            }

            return await DeleteDesignFiles(longsleeve);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSoccerJersey(int id)
        {
            var soccerjersey = await context.Soccerjerseys.FindAsync(id);
            if (soccerjersey == null)
            {
                return NotFound();
            }

            return await DeleteDesignFiles(soccerjersey);
        }

        // Helper methods
        private async Task<(string, string, string)> SaveUploadedFiles(IFormFile frontDesign, IFormFile backDesign, IFormFile optionalDesign = null)
        {
            var uploadsFolder = Path.Combine(env.WebRootPath, "Content/assets");
            EnsureDirectoryExists(uploadsFolder);

            var uniqueFrontFileName = await SaveFileAsync(frontDesign, uploadsFolder);
            var uniqueBackFileName = await SaveFileAsync(backDesign, uploadsFolder);
            string uniqueShortFileName = optionalDesign != null ? await SaveFileAsync(optionalDesign, uploadsFolder) : null;

            return (uniqueFrontFileName, uniqueBackFileName, uniqueShortFileName);
        }

        private async Task<string> SaveFileAsync(IFormFile file, string uploadsFolder)
        {
            var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return uniqueFileName;
        }

        private async Task<IActionResult> DeleteDesignFiles(Designs design)
        {
            var uploadsFolder = Path.Combine(env.WebRootPath, "Content/assets");
            DeleteFileIfExists(Path.Combine(uploadsFolder, design.FrontDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, design.BackDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, design.ShortsDesign));

            context.Designs.Remove(design);
            await context.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> DeleteDesignFiles(BasketballJersey jersey)
        {
            var uploadsFolder = Path.Combine(env.WebRootPath, "Content/assets");
            DeleteFileIfExists(Path.Combine(uploadsFolder, jersey.FrontDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, jersey.BackDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, jersey.ShortsDesign));

            context.BasketballJerseys.Remove(jersey);
            await context.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> DeleteDesignFiles(Longsleeve longsleeve)
        {
            var uploadsFolder = Path.Combine(env.WebRootPath, "Content/assets");
            DeleteFileIfExists(Path.Combine(uploadsFolder, longsleeve.FrontDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, longsleeve.BackDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, longsleeve.ShortsDesign));

            context.Longsleeves.Remove(longsleeve);
            await context.SaveChangesAsync();

            return Ok();
        }

        private async Task<IActionResult> DeleteDesignFiles(Soccerjersey soccerjersey)
        {
            var uploadsFolder = Path.Combine(env.WebRootPath, "Content/assets");
            DeleteFileIfExists(Path.Combine(uploadsFolder, soccerjersey.FrontDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, soccerjersey.BackDesign));
            DeleteFileIfExists(Path.Combine(uploadsFolder, soccerjersey.ShortsDesign));

            context.Soccerjerseys.Remove(soccerjersey);
            await context.SaveChangesAsync();

            return Ok();
        }

        private void DeleteFileIfExists(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private bool IsValidFileUpload(IFormFile frontDesign, IFormFile backDesign)
        {
            return frontDesign != null && backDesign != null && frontDesign.Length > 0 && backDesign.Length > 0;
        }

        private void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}

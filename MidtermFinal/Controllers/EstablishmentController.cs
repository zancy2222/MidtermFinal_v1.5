using Microsoft.AspNetCore.Mvc;
using MidtermFinal.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MidtermFinal.Controllers
{
    public class EstablishmentController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EstablishmentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadDetails(EstablishmentDetails model)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Image.CopyTo(fileStream);
                    }
                    model.ImagePath = "/uploads/" + uniqueFileName;
                }

                // Save model to the database (implement the logic as needed)

                return RedirectToAction("EstablishmentUsers");
            }

            return View("EstablishmentUsers", model);
        }
    }
}

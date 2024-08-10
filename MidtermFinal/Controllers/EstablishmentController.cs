using Microsoft.AspNetCore.Mvc;
using MidtermFinal.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MidtermFinal.Data;

namespace MidtermFinal.Controllers
{
    public class EstablishmentController : Controller
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly MidtermFinalDbContext _context;

        public EstablishmentController(MidtermFinalDbContext context)
        {
            _context = context;
            //_webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EstablishmentUser model)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                //if (model.Image != null)
                //{
                //    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                //    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                //    {
                //        model.Image.CopyTo(fileStream);
                //    }
                //    model.ImagePath = "/uploads/" + uniqueFileName;
                //}

                // Save model to the database (implement the logic as needed)
                _context.EstablishmentUsers.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("EstablishmentUsers");
            }

            return View("EstablishmentUsers", model);
        }
    }
}

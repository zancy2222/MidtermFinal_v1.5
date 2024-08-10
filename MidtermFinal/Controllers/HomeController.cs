using Microsoft.AspNetCore.Mvc;
using MidtermFinal.Data;
using MidtermFinal.Models;
using System.Diagnostics;

namespace MidtermFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MidtermFinalDbContext _context;

        public HomeController(ILogger<HomeController> logger, MidtermFinalDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError(string.Empty, "Please enter both email and password.");
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                // User found and password matches, redirect to HomePage
                return RedirectToAction("HomePage");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Landing()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Trips()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(IFormFile profileImage, string email, string name, string password, string repassword, string contact, string disability)
        {
            if (profileImage != null && profileImage.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", profileImage.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await profileImage.CopyToAsync(stream);
                }
            }

            // Here you can handle other form data, like saving them to the database.

            // Redirect or return a view with a success message.
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Signup(IFormFile profileImage, string email, string name, string password, string repassword, string contact, string disability)
        {
            if (ModelState.IsValid && password == repassword)
            {
                string profileImagePath = null;

                if (profileImage != null && profileImage.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    profileImagePath = Path.Combine(uploadsFolder, profileImage.FileName);
                    using (var stream = new FileStream(profileImagePath, FileMode.Create))
                    {
                        await profileImage.CopyToAsync(stream);
                    }
                }

                var user = new User
                {
                    Name = name,
                    Email = email,
                    Contact = contact,
                    Disability = disability,
                    ProfileImagePath = profileImagePath,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    RegisteredOn = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

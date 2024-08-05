using Microsoft.AspNetCore.Mvc;
using MidtermFinal.Models;

namespace MidtermFinal.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Sample data for demonstration
        private static List<User> GetSampleUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Contact = "+63 987 6543", RegisteredOn = DateTime.Now.AddMonths(-1) },
                new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Contact = "+63 123 4567", RegisteredOn = DateTime.Now.AddMonths(-2) },
                // Add more users as needed
            };
        }

        public IActionResult Users()
        {
            var users = GetSampleUsers();
            return View(users);
        }

        // Sample data for demonstration
        private static List<EstablishmentUser> GetSampleEstablishmentUsers()
        {
            return new List<EstablishmentUser>
            {
                new EstablishmentUser { Id = 1, Name = "Alice Brown", Email = "alice.brown@example.com", Contact = "+63 987 6543", Establishment = "Hotel ABC", RegisteredOn = DateTime.Now.AddMonths(-1) },
                new EstablishmentUser { Id = 2, Name = "Bob Green", Email = "bob.green@example.com", Contact = "+63 123 4567", Establishment = "Resort XYZ", RegisteredOn = DateTime.Now.AddMonths(-2) },
                // Add more users as needed
            };
        }

        public IActionResult EstablishmentUsers()
        {
            var users = GetSampleEstablishmentUsers();
            return View(users);
        }

        // This action can be used for adding establishment users
        public IActionResult AddEstablishmentUser()
        {
            // Implement the logic for adding a new establishment user
            return View();
        }

        // POST: Admin/AddEstablishmentUser
        [HttpPost]
        public IActionResult AddEstablishmentUser(EstablishmentUser newUser)
        {
            if (ModelState.IsValid)
            {
                // Add the new user to the data source
                var users = GetSampleEstablishmentUsers();
                newUser.Id = users.Count + 1;
                newUser.RegisteredOn = DateTime.Now;
                users.Add(newUser);

                // Redirect to the EstablishmentUsers page
                return RedirectToAction("EstablishmentUsers");
            }

            // If the model state is not valid, return the view with the current model
            return View(newUser);
        }



        // Sample data for demonstration
        private static List<Establishment> GetSampleEstablishments()
        {
            return new List<Establishment>
            {
                new Establishment { Id = 1, Title = "Hotel ABC", Description = "A luxurious hotel in the city center.", ImageUrl = "https://via.placeholder.com/150" },
                new Establishment { Id = 2, Title = "Resort XYZ", Description = "A beautiful resort by the beach.", ImageUrl = "https://via.placeholder.com/150" },
                // Add more establishments as needed
            };
        }

        public IActionResult ApproveEstablishments()
        {
            var establishments = GetSampleEstablishments();
            return View(establishments);
        }

        [HttpPost]
        public IActionResult ApproveEstablishment(int id)
        {
            // Logic to approve establishment
            // Remove establishment from the pending list and move to approved list
            return RedirectToAction("ApproveEstablishments");
        }

        [HttpPost]
        public IActionResult DeclineEstablishment(int id)
        {
            // Logic to decline establishment
            // Remove establishment from the pending list
            return RedirectToAction("ApproveEstablishments");
        }
    }
}

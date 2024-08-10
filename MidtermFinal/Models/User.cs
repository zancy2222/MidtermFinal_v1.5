using System.ComponentModel.DataAnnotations;

namespace MidtermFinal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(maximumLength: 128, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email field is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact field is required.")]
        [Phone]
        public string Contact { get; set; }

        public string Disability { get; set; }

        public string ProfileImagePath { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string PasswordHash { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}

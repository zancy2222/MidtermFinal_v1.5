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
        public string Email { get; set; }
        public string Contact { get; set; }
        public DateTime RegisteredOn { get; set; }
    }

}

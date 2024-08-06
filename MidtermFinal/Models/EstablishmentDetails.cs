using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MidtermFinal.Models
{
    public class EstablishmentDetails
    {
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}

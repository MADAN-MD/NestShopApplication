using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NestShopApplication.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}

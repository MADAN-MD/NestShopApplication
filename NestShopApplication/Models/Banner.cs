using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NestShopApplication.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [MaxLength(200)]
        public string Name { get; set; }

        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }
        
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; } //Navigation property

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}

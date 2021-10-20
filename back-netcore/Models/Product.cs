using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string UrlPath { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
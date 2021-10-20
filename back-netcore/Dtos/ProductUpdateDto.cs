using System.ComponentModel.DataAnnotations;

namespace GC.Dtos
{
    public class ProductUpdateDto
    {      
        [Required]  
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

    }
}
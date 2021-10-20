using System.ComponentModel.DataAnnotations;

namespace GC.Dtos
{
    public class CartUpdateDto
    {      
        [Required]  
        public int CartId { get; set; }
        [Required]  
        public int UserId { get; set; }
        [Required]  
        public int ProductId { get; set; }
        [Required]  
        public int Quantity { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
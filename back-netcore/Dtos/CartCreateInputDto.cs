using System.ComponentModel.DataAnnotations;

namespace GC.Dtos
{
    public class CartCreateInputDto
    {        
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Status { get; set; }
    }
}
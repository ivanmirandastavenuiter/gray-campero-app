using System.ComponentModel.DataAnnotations;

namespace GC.Dtos
{
    public class CartUpdateInputDto
    {      
        [Required]  
        public int CartId { get; set; }
        [Required]  
        public int UserId { get; set; }
        [Required]  
        public int ProductId { get; set; }
        [Required]  
        public int QuantityToUpdate { get; set; }
    }
}
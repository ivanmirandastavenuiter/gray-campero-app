using System.ComponentModel.DataAnnotations;

namespace GC.Dtos
{
    public class DeleteCartDto
    {        
        [Required]
        public int CartId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
    }
}
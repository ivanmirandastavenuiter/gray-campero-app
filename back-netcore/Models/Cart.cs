using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GC.Models
{
    public class Cart
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order=1)]
        public int CartId { get; set; }
        [Key]
        [Column(Order=2)]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Key]
        [Column(Order=3)]
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
         [Required]
        public string Status { get; set; }

    }
}
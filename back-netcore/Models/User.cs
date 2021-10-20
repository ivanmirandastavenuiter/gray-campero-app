using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
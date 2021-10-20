using System.Collections.Generic;
using GC.Dtos;
using GC.Models;

namespace GC.Data
{
    public interface ICartRepo 
    {
        IEnumerable<object> GetCartLinesForLoggedUser(int userId);
        void CreateCartLine(Cart cart);
        void UpdateCartLine();
        int GetFollowingId(int userId);
        Cart GetProductItemInCart(DeleteCartDto cart);
        void DeleteCartline(Cart cart);
        IEnumerable<Cart> GetActiveCartLinesForUser(int userId);
        IEnumerable<Cart> GetCartById(int id);
        bool SaveChanges();
    }
}
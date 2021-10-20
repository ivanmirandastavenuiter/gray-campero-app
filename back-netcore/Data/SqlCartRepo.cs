using System;
using System.Collections.Generic;
using System.Linq;
using GC.Dtos;
using GC.Models;

namespace GC.Data
{
    public class SqlCartRepo : ICartRepo
    {
        private readonly GCContext _context;

        public SqlCartRepo(GCContext context) 
        {
            _context = context;
        }

        public IEnumerable<object> GetCartLinesForLoggedUser(int userId)
        {
            var fullData = _context.Carts
            .Join(
                _context.Users,
                cart => cart.UserId,
                user => user.UserId,
                (cart, user) => new {
                    cartline = new CartReadDto {
                        CartId = cart.CartId,
                        UserId = cart.UserId,
                        ProductId = cart.ProductId,
                        Quantity = cart.Quantity,
                        Status = cart.Status
                    },
                    user = new UserReadDto {
                        UserId = user.UserId,
                        Name = user.Name,
                        Lastname = user.Lastname,
                        Email = user.Email
                    }
                }
            ).Join(
                _context.Products,
                cart => cart.cartline.ProductId,
                product => product.ProductId,
                (cart, product) => new {
                    cart.cartline,
                    product = new ProductReadDto {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Description = product.Description,
                        Price = product.Price,
                        Stock = product.Stock,
                        UrlPath = product.UrlPath
                    },
                    cart.user
                }
            ).Where(c => c.cartline.Status == "ACTIVE")
            .Where(c => c.user.UserId == userId).ToList();

            if (fullData.Count() > 0) 
            {
                UserReadDto loggedUser = fullData.First().user;
                IEnumerable<CartReadDto> cartLines = fullData.Select(item => (CartReadDto)item.cartline);
                IEnumerable<ProductReadDto> products = fullData.Select(item => (ProductReadDto)item.product);

                var fullResponse = new {
                    loggedUser = loggedUser,
                    cartLines = cartLines,
                    products = products
                };

                return new List<object>() {
                    fullResponse
                };
            }

            return fullData;
            
        }

        public void UpdateCartLine()
        {
            // Automapper auto updates the entity
        }

        public void CreateCartLine(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }

            _context.Carts.Add(cart);
        }

        public IEnumerable<Cart> GetCartById(int id) 
        {
            return _context.Carts.Where(c => c.CartId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public int GetFollowingId(int userId)
        {
            var cartLinesForLoggedUser = _context.Carts.Where(c => c.UserId == userId).OrderByDescending(c => c.CartId);

            if (cartLinesForLoggedUser.Count() == 0) return 0;
            return cartLinesForLoggedUser.First().CartId + 1;
        }

        public IEnumerable<Cart> GetActiveCartLinesForUser(int userId)
        {
            return _context.Carts.Where(c => c.Status == "ACTIVE").Where(c => c.UserId == userId);
        }

        public Cart GetProductItemInCart(DeleteCartDto deleteCartDto)
        {
            var userId = deleteCartDto.UserId;
            var cartId = deleteCartDto.CartId;
            var productId = deleteCartDto.ProductId;

            var cart = _context.Carts.Where(c => c.CartId == cartId)
                                     .Where(c => c.UserId == userId)
                                     .Where(c => c.ProductId == productId)
                                     .First();

            return cart;
        }

        public void DeleteCartline(Cart cart)
        {
            if (cart == null)
            {
                throw new ArgumentNullException(nameof(cart));
            }
            _context.Carts.Remove(cart);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GC.Data;
using GC.Dtos;
using GC.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GC.Controllers
{
    [Route("gc-api/cart")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepo _repository;

        public IMapper _mapper { get; }

        private readonly IUserRepo _userRepository;
        private IProductRepo _productRepository;

        public CartsController(
            ICartRepo repository, 
            IUserRepo userRepository, 
            IMapper mapper, IProductRepo productRepository
        )
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
        
        [HttpGet("{userId}")]
        public ActionResult <IEnumerable<Cart>> GetCartLinesForLoggedUser(int userId) 
        {
            var carts = _repository.GetCartLinesForLoggedUser(userId);

            return Ok(carts);
        }

        [HttpPost(Name = "CreateCartLine")]
        public ActionResult <CartReadDto> CreateCartLine(CartCreateInputDto cartCreateInputDto) 
        {
            // If CartId is populated. Means an active cart is found on db.
            if (cartCreateInputDto.CartId > 0) 
            {
                // Check if cart id is valid
                var cartId = cartCreateInputDto.CartId;
                var cartLines = _repository.GetCartById(cartId);

                if (cartLines.Count() == 0) 
                {
                    return NotFound();
                }

                // Check if user id is valid
                var userId = cartCreateInputDto.UserId;
                var userLogged = _userRepository.GetUserById(userId);

                if (userLogged == null) {
                    return NotFound();
                }

                // Check if product id is valid
                var productId = cartCreateInputDto.ProductId;
                var product = _productRepository.GetProductById(productId);

                if (product == null) 
                {
                    return NotFound();
                }

                // If validation ok, let's insert
                cartCreateInputDto.Status = "ACTIVE";

                var cartModel = _mapper.Map<Cart>(cartCreateInputDto);
                _repository.CreateCartLine(cartModel);
                _repository.SaveChanges();

                var cartCreatedDto = _mapper.Map<CartReadDto>(cartModel);
                return CreatedAtRoute(nameof(CreateCartLine), cartCreatedDto);

            } 
            else 
            {
                // If id is not there, we must create a new record
                var nextCartId = _repository.GetFollowingId(cartCreateInputDto.UserId);

                if (nextCartId == 0) 
                {
                    return NotFound();
                }

                // Check if product id is valid
                var productId = cartCreateInputDto.ProductId;
                var product = _productRepository.GetProductById(productId);

                if (product == null) 
                {
                    return NotFound();
                }
                
                // If validation ok, let's insert
                cartCreateInputDto.CartId = nextCartId;
                cartCreateInputDto.Status = "ACTIVE";

                var cartModel = _mapper.Map<Cart>(cartCreateInputDto);
                _repository.CreateCartLine(cartModel);
                _repository.SaveChanges();

                var cartCreatedDto = _mapper.Map<CartReadDto>(cartModel);
                return CreatedAtRoute(nameof(CreateCartLine), cartCreatedDto);
                
            }
        }

        [HttpPatch]
        public ActionResult UpdateCartLine(CartUpdateInputDto cartUpdateDto) 
        {
            var carts = _repository.GetCartById(cartUpdateDto.CartId);
            var selectedProductInCart = carts.Where(c => c.ProductId == cartUpdateDto.ProductId).First();

            bool isStockAvailable = this.IsStockAvailable(cartUpdateDto.ProductId, cartUpdateDto.QuantityToUpdate);

            if (!isStockAvailable)
            {
                return BadRequest("Stock exceeded");
            }

            if (selectedProductInCart == null) 
            {
                return NotFound();
            }

            var cartToPatch = _mapper.Map<CartUpdateDto>(selectedProductInCart);
            var patchDoc = new JsonPatchDocument<CartUpdateDto>();
            patchDoc.Replace(c => c.Quantity, cartUpdateDto.QuantityToUpdate);
            patchDoc.ApplyTo(cartToPatch, ModelState);

            if (!TryValidateModel(cartToPatch)) 
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(cartToPatch, selectedProductInCart);

            _repository.UpdateCartLine();

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPost("{userId}")]
        public ActionResult ConfirmCheckout(int userId) 
        {
            var activeCartLines = _repository.GetActiveCartLinesForUser(userId);
            if (activeCartLines.Count() == 0) 
            {
                return NotFound();
            }

            foreach (Cart activeCart in activeCartLines.ToList())
            {
                var stockOk = this.BalanceStock(activeCart.ProductId, activeCart.Quantity);

                if (stockOk.GetType() == typeof(BadRequestObjectResult)) {
                    return BadRequest("Error with stock");
                }

                var cartToPatch = _mapper.Map<CartUpdateDto>(activeCart);
                var patchDoc = new JsonPatchDocument<CartUpdateDto>();
                patchDoc.Replace(c => c.Status, "CHECKED");
                patchDoc.ApplyTo(cartToPatch, ModelState);

                if (!TryValidateModel(cartToPatch)) 
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(cartToPatch, activeCart);

                _repository.UpdateCartLine();
            }

            _repository.SaveChanges();

            return NoContent();
        }

        public ActionResult BalanceStock(int productId, int quantityConsumed) 
        {
            var productModel = _productRepository.GetProductById(productId);
            var productToPatch = _mapper.Map<ProductUpdateDto>(productModel);
            var patchDoc = new JsonPatchDocument<ProductUpdateDto>();

            if (productModel != null) 
            {
                if (!(productModel.Stock - quantityConsumed >= 0))
                {
                    return BadRequest("Limit for stock reached");
                }
        
                int balancedStock = productModel.Stock - quantityConsumed;
                patchDoc.Replace(p => p.Stock, balancedStock);
                patchDoc.ApplyTo(productToPatch, ModelState);

                if (!TryValidateModel(productToPatch)) 
                {
                    return ValidationProblem(ModelState);
                }

                _mapper.Map(productToPatch, productModel);
                return Ok();
            }
            else 
            {
                return NotFound();
            }
        }

        private bool IsStockAvailable(int productId, int quantityToUpdate) 
        {
            var selectedProduct = _productRepository.GetProductById(productId);
            return selectedProduct.Stock - quantityToUpdate >= 0;
        }

        [HttpDelete]
        public ActionResult DeleteCartline(DeleteCartDto deleteCartDto)
        {
            var cartModel = _repository.GetProductItemInCart(deleteCartDto);
            if(cartModel == null)
            {
                return NotFound();
            }
            _repository.DeleteCartline(cartModel);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BgsController
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("addToCart")]
        public IActionResult AddToCart([Required][FromBody] int productId)
        {
            _cartService.AddCartItem(productId, CurrentUserId);
            return Ok();
        }

        [HttpPost("deleteFromCart")]
        public IActionResult DeleteFromCart([Required][FromBody] int cartItemId)
        {
            _cartService.DeleteCartItem(cartItemId);
            return Ok();
        }

        [HttpGet("getCartItems")]
        public IActionResult GetCartItems()
        {
            var items = _cartService.GetCartItems(CurrentUserId);
            return Ok(items);
        }

        [HttpGet("getCartItemsCount")]
        public IActionResult GetCartItemsCount()
        {
            var count = _cartService.GetCartItemsCount(CurrentUserId);
            return Ok(count);
        }

        [HttpPost("updateCartItemQuantity")]
        public IActionResult UpdateCartItemQuantity(int cartItemId, int quantity)
        {
            _cartService.UpdateCartItemQuantity(cartItemId, quantity);
            return Ok();
        }

        

       


    }
}
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
    }
}
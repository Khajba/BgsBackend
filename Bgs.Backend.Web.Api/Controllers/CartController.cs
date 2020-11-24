using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult AddToCart(int productId)
        {
            _cartService.AddToCart(productId,CurrentUserId);
            return Ok();
        }

        [HttpPost("deleteFromCart")]
        public IActionResult DeleteFromCart(int cartItemId)
        {
            _cartService.DeleteFromCart(cartItemId);
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

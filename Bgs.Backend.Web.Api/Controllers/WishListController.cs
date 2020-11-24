using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bgs.Backend.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : BgsController
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpPost("addToWishList")]
        public IActionResult AddToWishList([Required][FromBody] int productId)
        {
            _wishListService.AddToWishList(productId, CurrentUserId);
            return Ok();
        }

        [HttpPost("removeFromWishList")]
        public IActionResult RemoveFromWishList([Required][FromBody] int productId)
        {
            _wishListService.RemoveFromWishList(productId);
            return Ok();
        }

        [HttpGet("getWishListItems")]
        public IActionResult GetWishListItems()
        {
            var items = _wishListService.GetWishListItems(CurrentUserId);
            return Ok(items);
        }
    }
}
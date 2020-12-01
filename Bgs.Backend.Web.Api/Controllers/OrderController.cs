using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BgsController
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getOrderItems")]
        public IActionResult GetOrderItems()
        {
            var items = _orderService.GetOrderItems(CurrentUserId);
            return Ok(items);
        }

        [HttpPost("placeOrder")]
        public IActionResult PlaceOrder(PlaceOrderModel model)
        {
            // _cartService.PlaceOrder(CurrentUserId, model.CartItemId,  model.Quantity, model.TotalPrice);
            return Ok();
        }

    }
}

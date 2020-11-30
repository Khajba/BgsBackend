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

    }
}

using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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

        [HttpGet("getOrders")]
        public IActionResult GetOrders([Required] int pageNumber, [Required] int pageSize)
        {
            var items = _orderService.GetOrders(CurrentUserId, pageNumber, pageSize);
            return Ok(items);
        }

        [HttpPost("placeOrder")]
        public IActionResult PlaceOrder()
        {
            _orderService.PlaceOrder(CurrentUserId);
            return Ok();
        }

        [HttpGet("getOrdersCount")]
        public IActionResult GetOrdersCount()
        {
            var count = _orderService.GetOrdersCount(CurrentUserId);
            return Ok(count);
        }

    }
}

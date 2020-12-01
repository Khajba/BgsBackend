﻿using Bgs.Backend.Web.Api.Models;
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

        [HttpGet("getOrders")]
        public IActionResult GetOrders()
        {
            var items = _orderService.GetOrders(CurrentUserId);
            return Ok(items);
        }

        [HttpPost("placeOrder")]
        public IActionResult PlaceOrder()
        {
            _orderService.PlaceOrder(CurrentUserId);
            return Ok();
        }

    }
}

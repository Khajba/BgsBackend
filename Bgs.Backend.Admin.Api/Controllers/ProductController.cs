using Bgs.Backend.Admin.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bgs.Backend.Admin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getProductType")]
        public IActionResult GetProductType()
        {
            var types = _productService.GetProductTypes();
            return Ok(types);
        }


    }
}

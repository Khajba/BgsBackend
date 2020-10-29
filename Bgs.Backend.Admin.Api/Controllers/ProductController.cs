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

        [HttpGet("getProductCategories")]
        public IActionResult GetProductCategories()
        {
            var types = _productService.GetProductCategories();
            return Ok(types);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(AddProductModel model)
        {
            var id = _productService.AddProduct(model.Name, model.Price.Value, model.CategoryId.Value, model.Description);
            return Ok(id);

        }

        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct(UpdateProductModel model)
        {
            _productService.UpdateProduct(model.Id, model.Name, model.Price.Value, model.CategoryId.Value, model.Description);
            return Ok();
        }

        [HttpPost("DeleteProduct")]
        public IActionResult DeleteProduct(DeleteProductModel model)
        {
            _productService.DeleteProduct(model.Id);
            return Ok();
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProduct([FromQuery] ProductFilterModel model)
        {
            var products = _productService.GetProducts(model.Name, model.PriceFrom, model.PriceTo, model.CategoryId, model.StockFrom, model.StockTo);
            return Ok(products);
        }




    }
}

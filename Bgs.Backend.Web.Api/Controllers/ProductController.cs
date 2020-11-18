﻿using Bgs.Backend.Web.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bgs.Backend.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BgsController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts([FromQuery] ProductFilterModel model)
        {
            var products = _productService.GetProducts(model.Name, model.PriceFrom, model.PriceTo, model.CategoryId, null, null, model.PageNumber, model.PageSize, model.ArtistId, model.DesignerId, model.MechanicsId);
            return Ok(products);
        }

        [HttpGet("getProductCategories")]
        public IActionResult GetProductCategories()
        {
            var products = _productService.GetProductCategories();
            return Ok(products);
        }

        [HttpGet("getProductDetails")]
        public IActionResult getProductDetails(int productId)
        {
            var details = _productService.GetProductDetails(productId);
            return Ok();
        }


        [HttpPost("addComment")]
        public IActionResult AddComment(AddCommentModel model)
        {
            _productService.AddComment(model.Id, CurrentUserId, model.Description);
            return Ok();
        }

        

    }
}

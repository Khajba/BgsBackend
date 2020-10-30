using Bgs.Backend.Admin.Api.Models;
using Bgs.Bll.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Mime;

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

        [HttpPost("addProduct")]
        public IActionResult AddProduct(AddProductModel model)
        {
            var id = _productService.AddProduct(model.Name, model.Price.Value, model.CategoryId.Value, model.Description);
            return Ok(id);

        }

        [HttpPost("updateProduct")]
        public IActionResult UpdateProduct(UpdateProductModel model)
        {
            _productService.UpdateProduct(model.Id, model.Name, model.Price.Value, model.CategoryId.Value, model.Description);
            return Ok();
        }

        [HttpPost("deleteProduct")]
        public IActionResult DeleteProduct(DeleteProductModel model)
        {
            _productService.DeleteProduct(model.Id);
            return Ok();
        }

        [HttpGet("getProducts")]
        public IActionResult GetProducts([FromQuery] ProductFilterModel model)
        {
            var products = _productService.GetProducts(model.Name, model.PriceFrom, model.PriceTo, model.CategoryId, model.StockFrom, model.StockTo, model.PageNumber, model.PageSize);
            return Ok(products);
        }

        [HttpGet("getProductById")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);

            return Ok(product);
        }


        [HttpPost("addProductStock")]
        public IActionResult AddProductStock(AddProductStockModel model)
        {
            _productService.AddProductQuantity(model.ProductId.Value, model.Quantity.Value);

            return Ok();
        }

        [HttpGet("getProductStock")]
        public IActionResult GetProductStock(int productId)
        {
            var productStock = _productService.GetProductStock(productId);
            return Ok(productStock);
        }

        [HttpGet("getProductsCount")]
        public IActionResult GetProductsCount([FromQuery] ProductFilterModel model)
        {
            var count = _productService.GetProductsCount(model.Name, model.PriceFrom, model.PriceTo, model.CategoryId, model.StockFrom, model.StockTo);
            return Ok(count);
        }

        [HttpPost("addProductAttachments")]
        public IActionResult AddProductAttachments([FromForm] AddProductAttachmentsModel model)
        {
            _productService.AddProductAttachment(model.ProductId, model.Files);
            return Ok();
        }

        [HttpGet("getProductAttachments")]
        public IActionResult GetProductsAttachments(int productId)
        {
            var attachments = _productService.GetProductAttachments(productId);
            return Ok(attachments);
        }

        [HttpGet("getAttachment")]
        public IActionResult GetAttachment(string fileName)
        {
            var filePath = Path.Combine("c:\\UploadedFiles", fileName);

            return PhysicalFile(filePath, MediaTypeNames.Image.Jpeg);
        }
    }
}

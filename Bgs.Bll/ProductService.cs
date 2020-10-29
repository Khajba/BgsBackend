using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Dal.Abstract;
using System.Collections.Generic;

namespace Bgs.Bll
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public int AddProduct(string name, decimal price, int categoryId, string description)
        {
            return _productRepository.AddProduct(name, price, categoryId, description, (int)ProductStatus.Active);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.UpdateProductStatus(id, (int)ProductStatus.Deleted);
        }

        public IEnumerable<ProductType> GetProductCategories()
        {
            var productType = _productRepository.GetProductCategories();
            return productType;
        }

        public IEnumerable<ProductDto> GetProducts(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo)
        {
            return _productRepository.GetProducts(name, priceFrom, priceTo, categoryId, stockFrom, stockTo, (int)ProductStatus.Active);
        }

        public void UpdateProduct(int id, string name, decimal price, int categoryId, string description)
        {
            _productRepository.UpdateProduct(id, name, price, categoryId, description);
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            product.Attachments = _productRepository.GetProductAttachments(id);
            return product;
        }

        public void AddProductQuantity(int productId, int quantity)
        {

            var currentQuantity = _productRepository.GetProductStock(productId);
            if (currentQuantity == null)
            {
                _productRepository.AddProductStock(productId, quantity);
            }
            else
            {
                _productRepository.UpdateProductStock(productId, currentQuantity.Value + quantity);
            }
        }

        public int GetProductStock(int productId)
        {
            var productStock = _productRepository.GetProductStock(productId);
            return productStock ?? 0;
        }
    }
}

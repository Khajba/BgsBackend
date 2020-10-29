using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System.Collections.Generic;

namespace Bgs.Dal.Abstract
{
    public interface IProductRepository
    {
        public int AddProduct(string name, decimal price, int categoryId, string description, int statusId);

        public void UpdateProduct(int id, string name, decimal price, int categoryId, string description);

        public void UpdateProductStatus(int id, int statusId);

        public IEnumerable<ProductDto> GetProducts(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? StockTo, int? statusId);

        public IEnumerable<ProductType> GetProductCategories();

        public Product GetProductById(int id);

        public IEnumerable<ProductAttachment> GetProductAttachments(int id);

        public int? GetProductStock(int productId);

        public void AddProductStock(int productId, int quantity);

        public void UpdateProductStock(int productId, int quantity);
    }
}

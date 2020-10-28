using Bgs.Common.Entities;
using Bgs.Common.Enum;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace Bgs.Dal.Abstract
{
    public interface IProductRepository
    {
        public void AddProduct(string name, float price, int categoryId, string description, int statusId);

        public void UpdateProduct(int id, string name, float price, int categoryId, string description);

        public void UdateProductStatus(int id, int statusId);

        public IEnumerable<Product> GetProducts(string name, float? priceFrom, float? priceTo, int? categoryId, int? stockFrom, int? StockTo, int? statusId);

        public Product GetById(int id);

        public IEnumerable<ProductType> GetProductCategories();
    }
}

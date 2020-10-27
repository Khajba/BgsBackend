using Bgs.Common.Entities;
using System.Collections.Generic;

namespace Bgs.Dal.Abstract
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);

        public bool EditProduct(Product product);

        public bool DeleteProduct(int id);

        public IEnumerable<Product> GetProducts();

        public Product GetById(int id);

        public IEnumerable<ProductType> GetProductTypes();
    }
}

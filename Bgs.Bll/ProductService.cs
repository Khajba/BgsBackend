using Bgs.Bll.Abstract;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public  ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        

        public int AddProduct(string name, float price, int categoryId, string description)
        {
            return _productRepository.AddProduct(name, price, categoryId,description,(int)ProductStatus.Active);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.UdateProductStatus(id, (int)ProductStatus.Deleted);
        }

        public IEnumerable<ProductType> GetProductCategories()
        {
            var productType = _productRepository.GetProductCategories();
            return productType;
        }

        public IEnumerable<Product> GetProducts(string name, float? priceFrom,float? priceTo, int? categoryId, int? stockFrom, int? stockTo)
        {
            return _productRepository.GetProducts(name, priceFrom, priceTo, categoryId, stockFrom, stockTo, (int)ProductStatus.Active
                );
        }

        public void UpdateProduct(int id, string name, float price, int categoryId, string description)
        {
            _productRepository.UpdateProduct(id, name, price, categoryId, description);
        }
    }
}

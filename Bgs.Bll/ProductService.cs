using Bgs.Bll.Abstract;
using Bgs.Common.Entities;
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
        public IEnumerable<ProductType> GetProductTypes()
        {
            var productType = _productRepository.GetProductTypes();
            return productType;
        }
    }
}

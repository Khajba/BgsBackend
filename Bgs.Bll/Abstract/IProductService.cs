using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IProductService
    {
        public IEnumerable<ProductType> GetProductCategories();

        public int AddProduct(string name, float price, int categoryId, string description);
        public void UpdateProduct(int id, string name, float price, int categoryId, string description);
        public void DeleteProduct(int id);
        public IEnumerable<ProductDto> GetProducts(string name, float? priceFrom,float? priceTo, int? categoryId, int? stockFrom, int? StockTo) ;
    }
}

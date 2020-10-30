﻿using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System.Collections.Generic;

namespace Bgs.Bll.Abstract
{
    public interface IProductService
    {
        public IEnumerable<ProductType> GetProductCategories();

        public int AddProduct(string name, decimal price, int categoryId, string description);

        public void UpdateProduct(int id, string name, decimal price, int categoryId, string description);

        public void DeleteProduct(int id);

        public IEnumerable<ProductDto> GetProducts(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? StockTo, int? pageNumber, int? pageSize);

        public Product GetProductById(int id);

        public void AddProductQuantity(int productId, int quantity);

        public int GetProductStock(int productId);
        public int GetProductsCount(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo);
    }
}

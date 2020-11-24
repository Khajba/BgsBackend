using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Bgs.Bll.Abstract
{
    public interface IProductService
    {
        IEnumerable<ProductType> GetProductCategories();

        int AddProduct(string name, decimal price, int categoryId, string description, int? artistId, int? designerId, int? mechanicsId);

        void UpdateProduct(int id, string name, decimal price, int categoryId, string description, int? artistId, int? designerId, int? mechanicsId);

        void DeleteProduct(int id);

        IEnumerable<ProductDto> GetProducts(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? StockTo, int? pageNumber, int? pageSize, int? artistId, int? designerId, int? mechanicsId, int sortOrder);

        Product GetProductById(int id);

        void AddProductQuantity(int productId, int quantity);

        int GetProductStock(int productId);

        int GetProductsCount(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo);

        void AddProductAttachment(int productId, IEnumerable<IFormFile> files);

        IEnumerable<ProductAttachment> GetProductAttachments(int productId);

        void SetPrimaryAttachment(int productId, int attachmentId);

        void RemoveProductAttachment(int attachmentId);

        ProductDetailsDto GetProductDetails(int productId);

        void AddComment(int productId, int userId, string description);

        IEnumerable<CommentDto> GetComments(int productId);

        


    }
}
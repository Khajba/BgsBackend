using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System;
using System.Collections.Generic;

namespace Bgs.Dal.Abstract
{
    public interface IProductRepository
    {
        int AddProduct(string name, decimal price, int categoryId, string description, int statusId, int? artistId, int? designerId, int? mechanicsId);

        void UpdateProduct(int id, string name, decimal price, int categoryId, string description, int? artistId, int? designerId, int? mechanicsId);

        void UpdateProductStatus(int id, int statusId);

        IEnumerable<ProductDto> GetProducts(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? pageNumber, int? pageSize, int? statusId, int? artistId, int? designerId, int? mechanicsId, int sortOrder);
       
        IEnumerable<ProductType> GetProductCategories();

        Product GetProductById(int id);

        IEnumerable<ProductAttachment> GetProductAttachments(int id);

        int GetProductAvailableStock(int productId);

        int? GetProductStock(int productId);

        void AddProductStock(int productId, int quantity);

        void UpdateProductStock(int productId, int quantity);

        int GetProductsCount(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? statusId);

        void AddProductAttachment(int productId, string attachmentUrl);

        void SetPrimaryAttachment(int productId, int attachmentId);

        void RemoveProductAttachment(int attachmentId);

        ProductDetailsDto GetProductDetails(int productId);

        IEnumerable<string> GetProductAttachmentsList(int productId);

        void AddProductComment(int productId, int userId, DateTime createDate, string description);

        IEnumerable<CommentDto> GetProductComments(int productid);

        public void AddBlockedProduct(int productId, int? quantity);

        public void UpdateBlockedProductQuantity(int productId, int? quantity);

        public int? GetBlockedProductQuantity(int productId);


    }
}

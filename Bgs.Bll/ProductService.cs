using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Bgs.Bll
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMultimediaService _multimediaService;

        public ProductService(IProductRepository productRepository, IMultimediaService multimediaService)
        {
            _productRepository = productRepository;
            _multimediaService = multimediaService;
        }

        public int AddProduct(string name, decimal price, int categoryId, string description, int? artist, int? designer, int? mechanics)
        {
            return _productRepository.AddProduct(name, price, categoryId, description, (int)ProductStatus.Active, artist, designer, mechanics);
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

        public IEnumerable<ProductDto> GetProducts(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? pageNumber, int? PageSize, int? artistId, int? designerId, int? mechanicsId)
        {
            return _productRepository.GetProducts(name, priceFrom, priceTo, categoryId, stockFrom, stockTo, pageNumber, PageSize, (int)ProductStatus.Active,artistId, designerId, mechanicsId);
        }

        public void UpdateProduct(int id, string name, decimal price, int categoryId, string description, int? artistId, int? designerId, int? mechanicsId)
        {
            _productRepository.UpdateProduct(id, name, price, categoryId, description, artistId, designerId, mechanicsId);
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

        public int GetProductsCount(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo)
        {
            return _productRepository.GetProductsCount(name, priceFrom, priceTo, categoryId, stockFrom, stockTo, (int)ProductStatus.Active);
        }

        public void AddProductAttachment(int productId, IEnumerable<IFormFile> files)
        {
            using (var transaction = new BgsTransactionScope())
            {
                foreach (var file in files)
                {
                    var attachmentUrl = _multimediaService.AddImage(file);
                    _productRepository.AddProductAttachment(productId, attachmentUrl);
                }

                transaction.Complete();
            }
        }

        public IEnumerable<ProductAttachment> GetProductAttachments(int productId)
        {
            return _productRepository.GetProductAttachments(productId);
        }

        public void SetPrimaryAttachment(int productId, int attachmentId)
        {
            _productRepository.SetPrimaryAttachment(productId, attachmentId);
        }

        public void RemoveProductAttachment(int attachmentId)
        {
            _productRepository.RemoveProductAttachment(attachmentId);
        }

        public ProductDetailsDto GetProductDetails(int productId)
        {
            var dto = _productRepository.GetProductDetails(productId);
            dto.ProductAttachments = _productRepository.GetProductAttachmentsList(productId);
            dto.Comments = _productRepository.GetComments(productId);

            return dto;

        }

        public void AddComment(int productId, int userId, string description)
        {
            _productRepository.AddComment(productId, userId, DateTime.Now, description);
        }


    }
}
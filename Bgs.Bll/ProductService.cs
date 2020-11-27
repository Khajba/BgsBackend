using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Bgs.Bll
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly HttpClient _httpClient;
        private readonly string _multimediaApiBaseUri;

        public ProductService(IProductRepository productRepository, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _productRepository = productRepository;
            _httpClient = httpClientFactory.CreateClient();
            _multimediaApiBaseUri = configuration["MultimediaApiBaseUri"];
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

        public IEnumerable<ProductDto> GetProducts(int? userId, string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? pageNumber, int? PageSize, int? artistId, int? designerId, int? mechanicsId, int sortOrder)
        {
            return _productRepository.GetProducts(userId,name, priceFrom, priceTo, categoryId, stockFrom, stockTo, pageNumber, PageSize, (int)ProductStatus.Active, artistId, designerId, mechanicsId, sortOrder);
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
            var productStock = _productRepository.GetProductAvailableStock(productId);
            return productStock;
        }

        public int GetProductsCount(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? artistId, int? designerId, int? mechanicsId)
        {
            return _productRepository.GetProductsCount(name, priceFrom, priceTo, categoryId, stockFrom, stockTo, (int)ProductStatus.Active, artistId, designerId, mechanicsId);
        }

        public void AddProductAttachment(int productId, IEnumerable<IFormFile> files)
        {
            using (var transaction = new BgsTransactionScope())
            {
                foreach (var file in files)
                {
                    var multiContent = FileToHttpContent(file);

                    var response = _httpClient.PostAsync($"{_multimediaApiBaseUri}/image/add", multiContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        _productRepository.AddProductAttachment(productId, response.Content.ReadAsStringAsync().Result);
                    }

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
            dto.Attachments = _productRepository.GetProductAttachments(productId).Select(x => x.AttachmentUrl);
            dto.Comments = _productRepository.GetProductComments(productId);

            return dto;

        }

        public void AddComment(int productId, int userId, string description)
        {
            _productRepository.AddProductComment(productId, userId, DateTime.Now, description);
        }

        public IEnumerable<CommentDto> GetComments(int productId)
        {
            return _productRepository.GetProductComments(productId);
        }

        #region Private Methods

        private MultipartFormDataContent FileToHttpContent(IFormFile file)
        {
            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
            {
                data = br.ReadBytes((int)file.OpenReadStream().Length);
            }

            var bytes = new ByteArrayContent(data);

            return new MultipartFormDataContent
            {
                { bytes, "file", file.FileName }
            };
        }

        #endregion
    }
}
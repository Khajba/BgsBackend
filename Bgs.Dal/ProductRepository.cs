using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Bgs.Dal
{
    public class ProductRepository : SqlServerRepository, IProductRepository
    {
        private const string _SchemaProduct = "Product";

        public ProductRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }

        public int AddProduct(string name, decimal price, int categoryId, string description, int statusId, int? artistId, int? designerId, int? mechanicsId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.AddProduct"))
            {
                cmd.AddParameter("Name", name);
                cmd.AddParameter("Price", price);
                cmd.AddParameter("CategoryId", categoryId);
                cmd.AddParameter("Description", description);
                cmd.AddParameter("StatusId", statusId);
                cmd.AddParameter("ArtistId", artistId);
                cmd.AddParameter("DesignerId", designerId);
                cmd.AddParameter("MechanicsId", mechanicsId);

                return cmd.ExecuteReaderPrimitiveClosed<int>("Id");
            }
        }

        public void UpdateProduct(int id, string name, decimal price, int categoryId, string description, int? artistId, int? designerId, int? mechanicsId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.UpdateProduct"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("Name", name);
                cmd.AddParameter("Price", price);
                cmd.AddParameter("CategoryId", categoryId);
                cmd.AddParameter("Description", description);
                cmd.AddParameter("ArtistId", artistId);
                cmd.AddParameter("DesignerId", designerId);
                cmd.AddParameter("MechanicsId", mechanicsId);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProductType> GetProductCategories()
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductCategories"))
            {
                return cmd.ExecuteReaderClosed<ProductType>();
            }
        }

        public void UpdateProductStatus(int id, int statusId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.UpdateProductStatus"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("StatusId", statusId);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProductDto> GetProducts(int? userId, string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? pageNumber, int? pageSize, int? statusId, int? artistId, int? designerId, int? mechanicsId, int sortOrder)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProducts"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("StatusIdActive", statusId);
                cmd.AddParameter("Name", name);
                cmd.AddParameter("PriceFrom", priceFrom);
                cmd.AddParameter("PriceTo", priceTo);
                cmd.AddParameter("CategoryId", categoryId);
                cmd.AddParameter("StockFrom", stockFrom);
                cmd.AddParameter("StockTo", stockTo);
                cmd.AddParameter("PageNumber", pageNumber);
                cmd.AddParameter("Pagesize", pageSize);
                cmd.AddParameter("ArtistId", artistId);
                cmd.AddParameter("DesignerId", designerId);
                cmd.AddParameter("MechanicsId", mechanicsId);
                cmd.AddParameter("SortOrder", sortOrder);

                return cmd.ExecuteReaderClosed<ProductDto>();
            }
        }

        public Product GetProductById(int id)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductById"))
            {
                cmd.AddParameter("Id", id);

                return cmd.ExecuteReaderSingleClosed<Product>();
            }
        }

        public IEnumerable<ProductAttachment> GetProductAttachments(int id)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductAttachments"))
            {
                cmd.AddParameter("ProductId", id);

                return cmd.ExecuteReaderClosed<ProductAttachment>();
            }
        }

        public void AddProductStock(int productId, int quantity)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.AddProductStock"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProductStock(int productId, int quantity)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.UpdateProductStock"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public int GetProductsCount(string name, decimal? priceFrom, decimal? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? statusId, int? artistId, int? designerId, int? mechanicsId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductsCount"))
            {
                cmd.AddParameter("StatusIdActive", statusId);
                cmd.AddParameter("Name", name);
                cmd.AddParameter("PriceFrom", priceFrom);
                cmd.AddParameter("PriceTo", priceTo);
                cmd.AddParameter("CategoryId", categoryId);
                cmd.AddParameter("StockFrom", stockFrom);
                cmd.AddParameter("StockTo", stockTo);
                cmd.AddParameter("artistId", artistId);
                cmd.AddParameter("designerId", designerId);
                cmd.AddParameter("mechanicsId", mechanicsId);


                return cmd.ExecuteReaderPrimitiveClosed<int>("Count");
            }
        }

        public void AddProductAttachment(int productId, string attachmentUrl)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.AddProductAttachment"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("AttachmentUrl", attachmentUrl);

                cmd.ExecuteNonQuery();
            }
        }

        public void SetPrimaryAttachment(int productId, int attachmentId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.SetPrimaryAttachment"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("AttachmentId", attachmentId);

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveProductAttachment(int attachmentId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.RemoveProductAttachment"))
            {
                cmd.AddParameter("Id", attachmentId);

                cmd.ExecuteNonQuery();
            }
        }

        public ProductDetailsDto GetProductDetails(int productId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProducDetails"))
            {
                cmd.AddParameter("Id", productId);

                return cmd.ExecuteReaderSingleClosed<ProductDetailsDto>();
            }
        }

        public IEnumerable<string> GetProductAttachmentsList(int productId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductAttachmentsList"))
            {
                cmd.AddParameter("ProductId", productId);

                return cmd.ExecuteReaderPrimitives<string>("attachment");
            }
        }

        public void AddProductComment(int productId, int userId, DateTime createDate, string description)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.AddProductComment"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("CreateDate", createDate);
                cmd.AddParameter("Description", description);

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<CommentDto> GetProductComments(int productId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductComments"))
            {
                cmd.AddParameter("ProductId", productId);

                return cmd.ExecuteReaderClosed<CommentDto>();
            }
        }

        public int GetProductAvailableStock(int productId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductAvailableStock"))
            {
                cmd.AddParameter("ProductId", productId);

                return cmd.ExecuteReaderPrimitiveClosed<int>("Quantity");
            }
        }

        public int? GetProductStock(int productId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductStock"))
            {
                cmd.AddParameter("ProductId", productId);

                return cmd.ExecuteReaderPrimitive<int?>("Quantity");
            }
        }

        public void AddBlockedProduct(int productId, int? quantity)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.AddBlockedProduct"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public int? GetBlockedProductQuantity(int productId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetBlockedProductQuantity"))
            {
                cmd.AddParameter("ProductId", productId);

                return cmd.ExecuteReaderPrimitive<int?>("Quantity");
            }
        }

        public void UpdateBlockedProductQuantity(int productId, int? quantity)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.UpdateBlockedProductQuantity"))
            {
                cmd.AddParameter("ProductId", productId);
                cmd.AddParameter("Quantity", quantity);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
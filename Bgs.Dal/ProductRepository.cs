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
        public int AddProduct(string name, float price, int categoryId, string description, int statusId)
        {
            using(var cmd = GetSpCommand($"{_SchemaProduct}.AddProduct"))
            {
                cmd.AddParameter("Name", name);
                cmd.AddParameter("Price", price);
                cmd.AddParameter("CategoryId", categoryId);
                cmd.AddParameter("Description", description);
                cmd.AddParameter("StatusId", statusId);

               return cmd.ExecuteReaderPrimitiveClosed<int>("Id");
            }
        }        

        public void UpdateProduct(int id, string name, float price, int categoryId, string description)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.UpdateProduct"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("Name", name);
                cmd.AddParameter("Price", price);
                cmd.AddParameter("CategoryId", categoryId);
                cmd.AddParameter("Description", description);

                cmd.ExecuteNonQuery();
            }
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<ProductType> GetProductCategories()
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProductCategories"))
            {
                return cmd.ExecuteReaderClosed<ProductType>();
            }
        }

        public void UdateProductStatus(int id, int statusId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.UpdateProductStatus"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("StatusId", statusId);
                

                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProductDto> GetProducts(string name, float? priceFrom, float? priceTo, int? categoryId, int? stockFrom, int? stockTo, int? statusId)
        {
            using (var cmd = GetSpCommand($"{_SchemaProduct}.GetProducts"))
            {

                cmd.AddParameter("StatusIdActive", statusId);
                return cmd.ExecuteReaderClosed<ProductDto>();
            }
        }
    }
}

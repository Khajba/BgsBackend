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
        private const string _schemaInternalUser = "Product";
        public ProductRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public bool EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var cmd = GetSpCommand($"{_schemaInternalUser}.GetProducts"))
            {


                return cmd.ExecuteReaderClosed<Product>();
            }
        }

        public IEnumerable<ProductType> GetProductTypes()
        {
            using (var cmd = GetSpCommand($"{_schemaInternalUser}.GetProductTypes"))
            {
                return cmd.ExecuteReaderClosed<ProductType>();
            }
        }
    }
}

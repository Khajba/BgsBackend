using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Dal
{
    public class CategoryRepository : SqlServerRepository, ICategoryRepository
    {
        private const string _schemaProduct = "Product";
        public CategoryRepository(IConfiguration configuration)
            : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }
        public void AddArtist(string name)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.AddArtist"))
            {
                cmd.AddParameter("Name", name);
                

                cmd.ExecuteNonQuery();
            };
        }

        public void AddDesigner(string name)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.AddDesigner"))
            {
                cmd.AddParameter("Name", name);


                cmd.ExecuteNonQuery();
            };
        }

        public void DeleteArtist(int Id)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.DeleteArtist"))
            {
                cmd.AddParameter("Id", Id);


                cmd.ExecuteNonQuery();
            };
        }

        public void DeleteDesigner(int Id)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.DeleteDesigner"))
            {
                cmd.AddParameter("Id", Id);


                cmd.ExecuteNonQuery();
            };
        }

        public IEnumerable<Artist> GetArtists()
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.GetArtists"))
            {
                

                return cmd.ExecuteReaderClosed<Artist>();
            }
        }

        public IEnumerable<Designer> GetDesigners()
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.GetDesigners"))
            {


                return cmd.ExecuteReaderClosed<Designer>();
            }
        }
    }
}

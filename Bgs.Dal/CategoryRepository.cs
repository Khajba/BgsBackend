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
        public void AddArtist(string name, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.AddArtist"))
            {
                cmd.AddParameter("Name", name);
                cmd.AddParameter("StatusIdActive", statusId);
                

                cmd.ExecuteNonQuery();
            };
        }

        public void AddDesigner(string name, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.AddDesigner"))
            {
                cmd.AddParameter("Name", name);
                cmd.AddParameter("StatusIdActive", statusId);

                cmd.ExecuteNonQuery();
            };
        }

        public void AddMechanics(string name, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.AddMechanics"))
            {
                cmd.AddParameter("Name", name);
                cmd.AddParameter("StatusIdActive", statusId);

                cmd.ExecuteNonQuery();
            };
        }

        public void UpdateArtistStatus(int id, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.UpdateArtistStatus"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("StatusId", statusId);


                cmd.ExecuteNonQuery();
            };
        }

        public void UpdateDesignerStatus(int id, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.UpdateDesignerStatus"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("StatusId", statusId);


                cmd.ExecuteNonQuery();
            };
        }

        public void UpdateMechanicsStatus(int id, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.UpdateMechanicsStatus"))
            {
                cmd.AddParameter("Id", id);
                cmd.AddParameter("StatusId", statusId);


                cmd.ExecuteNonQuery();
            };
        }

        public IEnumerable<Artist> GetArtists(int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.GetArtists"))
            {
                cmd.AddParameter("StatusIdActive", statusId);

                return cmd.ExecuteReader<Artist>();
            }
        }

        public IEnumerable<Designer> GetDesigners(int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.GetDesigners"))
            {
                cmd.AddParameter("StatusIdActive", statusId);

                return cmd.ExecuteReader<Designer>();
            }
        }

        public IEnumerable<Designer> GetMechanics(int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaProduct}.GetMechanics"))
            {
                cmd.AddParameter("StatusIdActive", statusId);

                return cmd.ExecuteReader<Designer>();
            }
        }
    }
}

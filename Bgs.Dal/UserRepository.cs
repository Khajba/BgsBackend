using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer;
using Bgs.DataConnectionManager.SqlServer.Extensions;
using Microsoft.Extensions.Configuration;
using System;

namespace Bgs.Dal
{
    public class UserRepository : SqlServerRepository, IUserRepository
    {
        private const string _schemaUser = "User";

        public UserRepository(IConfiguration configuration)
             : base(configuration, configuration.GetConnectionString("MainDatabase"))
        {

        }
        
        public User GetByCredentials(string email, string password, int statusId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserByCredentials"))
            {
                cmd.AddParameter("Email", email);
                cmd.AddParameter("Password", password);
                cmd.AddParameter("StatusIdActive", statusId);

                return cmd.ExecuteReaderSingleClosed<User>();
            }
        }

        public void AddUser(string email, string firstname, string lastname, string password, int statusId, string pincode)
        {
            
            using (var cmd = GetSpCommand($"{_schemaUser}.AddUser"))
            {
                cmd.AddParameter("Email", email);
                cmd.AddParameter("Firstname", firstname);
                cmd.AddParameter("Lastname", lastname);
                cmd.AddParameter("Password", password);
                cmd.AddParameter("StatusIdActive", statusId);
                cmd.AddParameter("Pincode", pincode);

                cmd.ExecuteNonQuery();
            };
        }

        public string GetAvailablePincode()
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetAvailablePincode"))
            {
                return cmd.ExecuteReaderPrimitive<string>("Pincode");
            };
        }

        public void ReleasePincode(string pincode, DateTime releaseDate)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.ReleasePincode"))
            {
                cmd.AddParameter("Pincode", pincode);
                cmd.AddParameter("ReleaseDate", releaseDate);

                cmd.ExecuteNonQuery();
            }
        }

        public User GetUserById(int Id)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserById"))
            {
                cmd.AddParameter("Id", Id);

                return cmd.ExecuteReaderSingleClosed<User>();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserByEmail"))
            {
                cmd.AddParameter("Email", email);


                return cmd.ExecuteReaderSingleClosed<User>();
            }
        }
    }
}
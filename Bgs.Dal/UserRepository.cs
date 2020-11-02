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
        
        public User GetByCredentials(string email, string password)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserByCredentials"))
            {
                cmd.AddParameter("Email", email);
                cmd.AddParameter("Password", password);

                return cmd.ExecuteReaderSingleClosed<User>();
            }
        }

        public void AddUser(string email, string firstname, string lastname, string password, int statusId, int pincode)
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

        public int GetAvailablePincode()
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetAvailablePincode"))
            {
                return cmd.ExecuteReaderPrimitive<int>("Pincode");
            };
        }

        public void ReleasePincode(int pin, DateTime releaseDate)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.ReleasePincode"))
            {
                cmd.AddParameter("Pincode", pin);
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
    }
}
using Bgs.Common.Dtos;
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

                return cmd.ExecuteReaderSingle<User>();
            }
        }

        public UserDetailsDto GetUserDetails(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserDetails"))
            {
                cmd.AddParameter("Id", userId);

                return cmd.ExecuteReaderSingle<UserDetailsDto>();
            }
        }

        public UserAddressDto GetUserAddress(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserAddress"))
            {
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderSingle<UserAddressDto>();

            }
        }

        public UserPaymentDto GetUserPaymentDetails(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetPaymentDetails"))
            {
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderSingle<UserPaymentDto>();
            }
        }

        public void UpdateDetails(int userId, string firstname, string lastname)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdateUserDetails"))
            {
                cmd.AddParameter("Id", userId);
                cmd.AddParameter("Firstname", firstname);
                cmd.AddParameter("Lastname", lastname);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdateUserAddress"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("FullName", fullName);
                cmd.AddParameter("Line1", line1);
                cmd.AddParameter("Line2", line2);
                cmd.AddParameter("City", city);
                cmd.AddParameter("State", state);
                cmd.AddParameter("ZipCode", zipCode);
                cmd.AddParameter("PhoneNumber", phoneNumber);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddUserAddress"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("FullName", fullName);
                cmd.AddParameter("Line1", line1);
                cmd.AddParameter("Line2", line2);
                cmd.AddParameter("City", city);
                cmd.AddParameter("State", state);
                cmd.AddParameter("ZipCode", zipCode);
                cmd.AddParameter("PhoneNumber", phoneNumber);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdatePaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdatePaymentDetails"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("CardholderName", cardholderName);
                cmd.AddParameter("cardNumber", cardNumber);
                cmd.AddParameter("ExpirationMonth", expirationMonth);
                cmd.AddParameter("expirationYear", expirationYear);
                cmd.AddParameter("Cvv2", cvv2);

                cmd.ExecuteNonQuery();
            }
        }

        public void AddPaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.AddPaymentDetails"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("CardholderName", cardholderName);
                cmd.AddParameter("cardNumber", cardNumber);
                cmd.AddParameter("ExpirationMonth", expirationMonth);
                cmd.AddParameter("expirationYear", expirationYear);
                cmd.AddParameter("Cvv2", cvv2);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateUserPassword(int userId, string password)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdateUserPassword"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("Password", password);


                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateBalance(int userId, decimal? amount)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdateBalance"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("Amount", amount);

                cmd.ExecuteNonQuery();
            }
        }

        public decimal? GetBalance(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetBalance"))
            {
                cmd.AddParameter("UserId", userId);

                return cmd.ExecuteReaderPrimitive<decimal?>("Balance");
            };
        }

        public UserForPasswordUpdateDto GetUserForPasswordUpdate(int userId)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.GetUserForPasswordUpdate"))
            {
                cmd.AddParameter("Id", userId);

                return cmd.ExecuteReaderSingle<UserForPasswordUpdateDto>();
            }
        }

        public void UpdateUserAvatarUrl(int userId, string avatarUrl)
        {
            using (var cmd = GetSpCommand($"{_schemaUser}.UpdateUserAvatarUrl"))
            {
                cmd.AddParameter("UserId", userId);
                cmd.AddParameter("AvatarUrl", avatarUrl);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
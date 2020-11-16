using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using System;

namespace Bgs.Dal.Abstract
{
    public interface IUserRepository
    {
        public User GetUserByEmail ( string email);
        public void AddUser(string email, string firstname, string lastname, string password, int statudId, string pincode);

        public User GetUserById(int Id);

        public string GetAvailablePincode();

        public void ReleasePincode(string pincode, DateTime releaseDate);

        public User GetByCredentials(string email, string password, int statusId);

        public UserDetailsDto GetUserDetails(int userId);

        public UserAddressDto GetUserAddress(int userId);

        public UserPaymentDto GetUserPaymentDetails(int userId);
    }
}
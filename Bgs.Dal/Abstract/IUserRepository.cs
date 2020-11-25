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

        public void UpdateDetails(string firstname, string lastname);

        public void UpdateUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber);

        public void AddUserAddress(int userId,string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber);        

        public void UpdatePaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2);

        public void AddPaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2);

        public void UpdateUserPassword(int userId, string password);

        public void UpdateBalance(int userId, decimal amount);

        public decimal? GetBalance(int userId);

        public UserForPasswordUpdateDto GetUserForPasswordUpdate(int userId);


    }
}
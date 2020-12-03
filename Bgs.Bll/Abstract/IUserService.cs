using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;

namespace Bgs.Bll.Abstract
{
    public interface IUserService
    {
        public void RegisterUser(string email, string firstname, string lastname, string password);
        public User GetUserById(int Id);
        public User AuthenticateUser(string email, string password);
        public void SaveDetails(int userId, string fisrtname, string lastname);
        public void SaveUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber);
        public void SavePaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2);
        public UserAccountDto GetUserAccountDetails(int userId);
        public UserAddressDto GetUserAddress(int userId);
        public UserPaymentDto GetUserPaymentDetails(int userId);
        public void ChangeUserPassword(int userId, string oldPassword, string newPassword);
        public void AddBalance(int userId, decimal amount);
        public decimal GetBalance(int userId);
        public string UploadUserAvatar(int userId, IFormFile file);
        public void DeleteAvatar(int userId);
        public IEnumerable<UserListItemDto> GetUsers(string pinCode, string email, string firstname, string lastname, int? pageNumber, int? PageSize);
        public AdminUserDetailsDto GetDetails(int userId, int pageNumber, int pageSize);
        public int GetUsersCount(string pinCode, string email, string firstname, string lastname);
    }
}
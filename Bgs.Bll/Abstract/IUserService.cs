using Bgs.Common.Dtos;
using Bgs.Common.Entities;

namespace Bgs.Bll.Abstract
{
    public interface IUserService
    {
        public void RegisterUser(string email, string firstname, string lastname, string password);
        public User GetUserById(int Id);
        public User AuthenticateUser(string email, string password);
        public void SaveDetails(string fisrtname, string lastname);
        public void SaveUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber);
        public void SavePaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2);
        public UserDetailsDto GetUserDetails(int userId);
        public UserAddressDto GetUserAddress(int userId);
        public UserPaymentDto GetUserPaymentDetails(int userId);
        public void ChangeUserPassword(int userId, string oldPassword, string newPassword);
        public void AddBalance(int userId, decimal amount);
        public decimal GetBalance(int userId);
    }
}
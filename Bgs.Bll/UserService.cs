using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using Bgs.Utility.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Bgs.Bll
{
    public class UserService : IUserService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly HttpClient _httpClient;
        private readonly string _multimediaApiBaseUri;

        public UserService(
            IUserRepository userRepository,
            IHttpClientFactory httpClientFactory,
            ITransactionRepository transactionRepository,
            IConfiguration configuration,
            IOrderRepository orderRepository
            )
        {
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _httpClient = httpClientFactory.CreateClient();
            _multimediaApiBaseUri = configuration["MultimediaApiBaseUri"];
            _orderRepository = orderRepository;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                throw new BgsException((int)WebApiErrorCodes.EmailOrPasswordIncorrect);
            }

            if (user.StatusId != (int)UserStatus.Active)
            {
                throw new BgsException((int)WebApiErrorCodes.EmailOrPasswordIncorrect);
            }

            user = _userRepository.GetByCredentials(email, password.ToSHA256(user.Pincode), (int)UserStatus.Active);

            return user;


        }

        public User GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }

        public void RegisterUser(string email, string firstname, string lastname, string password)
        {
            var pincode = _userRepository.GetAvailablePincode();
            var user = _userRepository.GetUserByEmail(email);

            if (user != null)
            {
                throw new BgsException((int)WebApiErrorCodes.EmailAlreadyExists);
            }

            using (var transaction = new BgsTransactionScope())
            {

                _userRepository.AddUser(email, firstname, lastname, password.ToSHA256(pincode), (int)UserStatus.Active, pincode);
                _userRepository.ReleasePincode(pincode, DateTime.Now);

                transaction.Complete();
            }

        }

        public UserAccountDto GetUserAccountDetails(int userId)
        {
            var userDetails = _userRepository.GetUserDetails(userId);
            var userAddress = _userRepository.GetUserAddress(userId);
            var paymentDetails = _userRepository.GetUserPaymentDetails(userId);

            return new UserAccountDto
            {
                UserDetails = userDetails,
                UserAddress = userAddress,
                PaymentDetails = paymentDetails
            };
        }

        public UserAddressDto GetUserAddress(int userId)
        {
            return _userRepository.GetUserAddress(userId);
        }

        public UserPaymentDto GetUserPaymentDetails(int userId)
        {
            return _userRepository.GetUserPaymentDetails(userId);
        }

        public void SaveDetails(int userId, string firstname, string lastname)
        {
            _userRepository.UpdateDetails(userId, firstname, lastname);
        }

        public void SaveUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber)
        {
            var address = _userRepository.GetUserAddress(userId);
            if (address == null)
            {
                _userRepository.AddUserAddress(userId, fullName, line1, line2, city, state, zipCode, phoneNumber);
            }
            else
            {
                _userRepository.UpdateUserAddress(userId, fullName, line1, line2, city, state, zipCode, phoneNumber);
            }
        }

        public void SavePaymentDetails(int userId, string cardholderName, string cardNumber, int expirationMonth, int expirationYear, string cvv2)
        {
            var paymentDetails = _userRepository.GetUserPaymentDetails(userId);

            if (paymentDetails == null)
            {
                _userRepository.AddPaymentDetails(userId, cardholderName, cardNumber, expirationMonth, expirationYear, cvv2);
            }

            else
            {
                _userRepository.UpdatePaymentDetails(userId, cardholderName, cardNumber, expirationMonth, expirationYear, cvv2);
            }

        }

        public void ChangeUserPassword(int userId, string oldPassword, string newPassword)
        {

            var user = _userRepository.GetUserForPasswordUpdate(userId);

            if (user.Password == oldPassword.ToSHA256(user.Pincode))
            {
                _userRepository.UpdateUserPassword(userId, newPassword.ToSHA256(user.Pincode));
            }

            else
            {
                throw new BgsException((int)WebApiErrorCodes.OldPasswordIsIncorrect);
            }
        }

        public void AddBalance(int userId, decimal amount)
        {
            var balance = _userRepository.GetBalance(userId) ?? 0;
            balance = balance + amount;

            using (var transaction = new BgsTransactionScope())
            {
                _userRepository.UpdateBalance(userId, balance);
                _transactionRepository.AddTransaction((int)TransactionType.Deposit, userId, DateTime.Now, amount);
                transaction.Complete();


            };
        }

        public decimal GetBalance(int userId)
        {
            return _userRepository.GetBalance(userId) ?? 0;
        }

        public string UploadUserAvatar(int userId, IFormFile file)
        {

            var multiContent = file.ToHttpContent();

            var response = _httpClient.PostAsync($"{_multimediaApiBaseUri}/image/add", multiContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var avatarUrl = response.Content.ReadAsStringAsync().Result;
                _userRepository.UpdateUserAvatarUrl(userId, avatarUrl);
                return avatarUrl;
            }

            throw new BgsException((int)WebApiErrorCodes.CouldNotUploadAvatar);


        }

        public void DeleteAvatar(int userId)
        {
            _userRepository.UpdateUserAvatarUrl(userId, null);
        }

        public IEnumerable<UserListItemDto> GetUsers(string pinCode, string email, string firstname, string lastname)
        {
            return _userRepository.GetUsers(pinCode, email, firstname, lastname);
        }

        public AdminUserDetailsDto GetDetails(int userId)
        {
            var details = _userRepository.GetUserDetails(userId);
            var orders = _orderRepository.GetOrders(userId);
            var transactions = _transactionRepository.GetTransactions(userId, null, null, null, null, null, null);

            return new AdminUserDetailsDto
            {
                UserDetails = details,
                UserOrders = orders,
                Transactions = transactions
            };

        }
    }
}
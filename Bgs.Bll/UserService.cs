using Bgs.Bll.Abstract;
using Bgs.Common.Dtos;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
using Bgs.Utility.Extensions;
using System;

namespace Bgs.Bll
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);

            if (user.StatusId != (int)UserStatus.Active)
            {
                throw new BgsException((int)WebApiErrorCodes.EmailOrPasswordIncorrect);
            }

            user = _userRepository.GetByCredentials(email, password.ToSHA256(user.Pincode), (int)UserStatus.Active);

            if (user == null)
            {
                throw new BgsException((int)WebApiErrorCodes.EmailOrPasswordIncorrect);
            }
            else
            {
                return user;
            }

        }

        public User GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }

        public void RegisterUser(string email, string firstname, string lastname, string password)
        {
            var pincode = _userRepository.GetAvailablePincode();
            var user = _userRepository.GetUserByEmail(email);

            if (user != null){
                throw new BgsException((int)WebApiErrorCodes.EmailAlreadyExists);
            }

            using (var transaction = new BgsTransactionScope())
            {

                _userRepository.AddUser(email, firstname, lastname, password.ToSHA256(pincode), (int)UserStatus.Active, pincode);
                _userRepository.ReleasePincode(pincode, DateTime.Now);

                transaction.Complete();
            }

        }

        public UserDetailsDto GetUserDetails(int userId)
        {
            return _userRepository.GetUserDetails(userId);
        }

        public UserAddressDto GetUserAddress(int userId)
        {
            return _userRepository.GetUserAddress(userId);
        }

        public UserPaymentDto GetUserPaymentDetails(int userId)
        {
            return _userRepository.GetUserPaymentDetails(userId);
        }

        public void SaveDetails(string firstname, string lastname)
        {
            _userRepository.UpdateDetails(firstname, lastname);
        }

        public void SaveUserAddress(int userId, string fullName, string line1, string line2, string city, string state, string zipCode, string phoneNumber)
        {
            var address = _userRepository.GetUserAddress(userId);
            if(address == null)
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

            if(paymentDetails == null)
            {
                _userRepository.AddPaymentDetails(userId, cardholderName, cardNumber, expirationMonth, expirationYear, cvv2);
            }

            else
            {
                _userRepository.UpdatePaymentDetails(userId, cardholderName, cardNumber, expirationMonth, expirationYear, cvv2);
            }

        }
    }

}

using Bgs.Bll.Abstract;
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
    }
}

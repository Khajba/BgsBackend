using Bgs.Bll.Abstract;
using Bgs.Common.Entities;
using Bgs.Common.Enum;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;
using Bgs.DataConnectionManager.SqlServer.SqlClient;
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
            var user = _userRepository.GetByCredentials(email, password);

            if (user == null)
            {
                throw new BgsException((int)AdminApiErrorCodes.EmailOrPasswordIncorrect);
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
            using (var transaction = new BgsTransactionScope())
            {
                var pin = _userRepository.GetAvailablePincode();
                _userRepository.AddUser(email, firstname, lastname, password, (int)UserStatus.Active, pin);
                _userRepository.ReleasePincode(pin, DateTime.Now);


                transaction.Complete();
            }
            
        }
    }
}

using Bgs.Bll.Abstract;
using Bgs.Dal.Abstract;

namespace Bgs.Bll
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AuthenticateUser(string email, string password)
        {
            var user = _userRepository.GetByCredentials(email, password);

            return user != null;

        }
    }
}

using Bgs.Common.Entities;
using Bgs.Dal.Abstract;

namespace Bgs.Dal
{
    public class UserRepository : IUserRepository
    {
        public User GetByCredentials(string email, string password)
        {
            return null;
        }
    }
}
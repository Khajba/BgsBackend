using Bgs.Common.Entities;

namespace Bgs.Dal.Abstract
{
    public interface IUserRepository
    {
        public User GetByCredentials(string email, string password);
    }
}
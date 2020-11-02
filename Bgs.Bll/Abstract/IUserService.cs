using Bgs.Common.Entities;

namespace Bgs.Bll.Abstract
{
    public interface IUserService
    {
        public void RegisterUser(string email, string firstname, string lastname, string password);
        public User GetUserById(int Id);
        public User AuthenticateUser(string email, string password);
    }
}
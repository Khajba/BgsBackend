using Bgs.Common.Entities;
using Bgs.Dal.Abstract;
using System.Collections.Generic;

namespace Bgs.Dal
{
    public class UserRepository : IUserRepository
    {
        private List<User> Users = new List<User>();

        public User GetByCredentials(string email, string password)
        {
            var user = Users.Find(u => u.Email == email && u.Password == password);

            return user;
        }
    }
}
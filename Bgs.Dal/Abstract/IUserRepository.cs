using Bgs.Common.Entities;
using System;

namespace Bgs.Dal.Abstract
{
    public interface IUserRepository
    {
        public void AddUser(string email, string firstname, string lastname, string password, int statudId, int pincode);

        public User GetUserById(int Id);

        public int GetAvailablePincode();

        public void ReleasePincode(int pin, DateTime releaseDate);

        public User GetByCredentials(string email, string password);
    }
}
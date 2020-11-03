using Bgs.Common.Entities;
using System;

namespace Bgs.Dal.Abstract
{
    public interface IUserRepository
    {
        public User GetUserByEmail ( string email);
        public void AddUser(string email, string firstname, string lastname, string password, int statudId, string pincode);

        public User GetUserById(int Id);

        public string GetAvailablePincode();

        public void ReleasePincode(string pincode, DateTime releaseDate);

        public User GetByCredentials(string email, string password, int statusId);
    }
}
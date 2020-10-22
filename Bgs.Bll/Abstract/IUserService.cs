using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Bll.Abstract
{
    public interface IUserService
    {
        public bool AuthenticateUser(string email, string password);     

        
    }
}

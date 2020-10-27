using Bgs.Common.Entities;

namespace Bgs.Bll.Abstract
{
    public interface IInternalUserService
    {
        public InternalUser AuthenticateUser(string email, string password);
    }
}

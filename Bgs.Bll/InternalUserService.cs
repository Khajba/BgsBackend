using Bgs.Bll.Abstract;
using Bgs.Common.Entities;
using Bgs.Common.ErrorCodes;
using Bgs.Core.Exceptions;
using Bgs.Dal.Abstract;

namespace Bgs.Bll
{
    public class InternalUserService : IInternalUserService
    {
        private readonly IInternalUserRepository _internalUserRepository;

        public InternalUserService(IInternalUserRepository internalUserRepository)
        {
            _internalUserRepository = internalUserRepository;
        }

        public InternalUser AuthenticateUser(string email, string password)
        {
            var user = _internalUserRepository.GetUserByCredentials(email, password);

            if(user == null)
            {
                throw new BgsException((int)AdminApiErrorCodes.EmailOrPasswordIncorrect);
            }

            else
            {
                return user;
            }
            
        }
    }
}

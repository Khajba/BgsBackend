namespace Bgs.Bll.Abstract
{
    public interface IUserService
    {
        public bool AuthenticateUser(string email, string password);
    }
}
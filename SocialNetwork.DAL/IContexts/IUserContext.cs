using SocialNetwork.Models;

namespace SocialNetwork.DAL.IContexts
{
    public interface IUserContext
    {
        User RegisterUser(User user);
        User GetUser(User user);
        int CheckDublicate(User user);
        int VerifyUser(User user);
    }
}

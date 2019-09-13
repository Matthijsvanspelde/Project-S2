using SocialNetwork.Models;

namespace SocialNetwork.Logic.ILogic
{
    public interface IUserLogic
    {
        User RegisterUser(User user);
        User GetUser(User user);
        int CheckDublicate(User user);
        int VerifyUser(User user);
    }
}

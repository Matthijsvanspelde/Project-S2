using SocialNetwork.Models;

namespace SocialNetwork.Logic.ILogic
{
    public interface IUserLogic
    {
        User RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        int CheckDublicate(User user);
        int VerifyUser(User user);
    }
}

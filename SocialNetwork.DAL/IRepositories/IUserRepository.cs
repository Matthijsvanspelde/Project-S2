using SocialNetwork.Models;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IUserRepository
    {
        User RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        int CheckDublicate(User user);
        int VerifyUser(User user);
    }
}

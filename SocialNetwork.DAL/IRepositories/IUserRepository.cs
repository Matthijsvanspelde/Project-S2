using SocialNetwork.Models;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IUserRepository
    {
        User RegisterUser(User user);
        User GetUser(User user);
        int CheckDublicate(User user);
        int VerifyUser(User user);
    }
}

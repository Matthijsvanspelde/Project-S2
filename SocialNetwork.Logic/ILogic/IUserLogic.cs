using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IUserLogic
    {
        User RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        User EditProfileDetails(User user);
        IEnumerable<User> GetSearchResult(string Searchterm);
        int CheckDublicate(User user);
        int VerifyUser(User user);
    }
}

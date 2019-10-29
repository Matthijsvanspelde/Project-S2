using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IUserLogic
    {
        void RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        void EditProfileDetails(User user);
        IEnumerable<User> GetSearchResult(string Searchterm);
        IEnumerable<User> GetFollowers(User user);
        int CheckDublicate(User user);
        int VerifyUser(User user);
        bool CheckIfProfileExists(int Id);
    }
}

using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IUserLogic
    {
        bool RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        bool EditProfileDetails(User user);
        IEnumerable<User> GetSearchResult(string Searchterm);
        IEnumerable<User> GetFollowers(User user);
        IEnumerable<User> GetFollowing(User user);
        bool DoesUsernameExist(User user);
        bool DoesUserCombinationMatch(User user);
        bool DoesProfileExist(int Id);
        void DeleteUserAfterUnitTest(string username);
    }
}

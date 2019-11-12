using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IUserRepository
    {
        void RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        void EditProfileDetails(User user);
        IEnumerable<User> GetSearchResult(string Searchterm);
        IEnumerable<User> GetFollowers(User user);
        bool DoesUsernameExist(User user);
        bool DoesUserCombinationMatch(User user);
        bool DoesProfileExist(int Id);
    }
}

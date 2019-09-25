using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface IUserContext
    {
        void RegisterUser(User user);
        User GetSessionId(User user);
        User GetUserDetails(User user);
        void EditProfileDetails(User user);
        IEnumerable<User> GetSearchResult(string Searchterm);
        int CheckDublicate(User user);
        int VerifyUser(User user);

    }
}

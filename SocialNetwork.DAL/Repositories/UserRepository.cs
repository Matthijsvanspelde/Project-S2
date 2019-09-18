using SocialNetwork.DAL.IContexts;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : IUserRepository 
    {
        private readonly IUserContext _IUserContext;

        public UserRepository(IUserContext IUserContext)
        {
            _IUserContext = IUserContext;
        }

        public User RegisterUser(User user)
        {
            return _IUserContext.RegisterUser(user);
        }

        public User GetSessionId(User user)
        {
            return _IUserContext.GetSessionId(user);
        }

        public User GetUserDetails(User user)
        {
            return _IUserContext.GetUserDetails(user);
        }

        public User EditProfileDetails(User user)
        {
            return _IUserContext.EditProfileDetails(user);
        }

        public IEnumerable<User> GetSearchResult(string Searchterm)
        {
            return _IUserContext.GetSearchResult(Searchterm);
        }

        public int CheckDublicate(User user)
        {
            int UserCount = _IUserContext.CheckDublicate(user);
            return UserCount;
        }

        public int VerifyUser(User user)
        {
            int UserCount = _IUserContext.VerifyUser(user);
            return UserCount;
        }
    }
}

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

        public void RegisterUser(User user)
        {
            _IUserContext.RegisterUser(user);
        }

        public User GetSessionId(User user)
        {
            return _IUserContext.GetSessionId(user);
        }

        public User GetUserDetails(User user)
        {
            return _IUserContext.GetUserDetails(user);
        }

        public void EditProfileDetails(User user)
        {
            _IUserContext.EditProfileDetails(user);
        }

        public IEnumerable<User> GetSearchResult(string Searchterm)
        {
            return _IUserContext.GetSearchResult(Searchterm);
        }

        public IEnumerable<User> GetFollowers(User user)
        {
            return _IUserContext.GetFollowers(user);
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

        public bool CheckIfProfileExists(int Id)
        {
            bool DoesExist = _IUserContext.CheckIfProfileExists(Id);
            return DoesExist;
        }


    }
}

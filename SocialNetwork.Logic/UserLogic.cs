using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void RegisterUser(User user)
        {
            _userRepository.RegisterUser(user);
        }

        public User GetSessionId(User user)
        {
            return _userRepository.GetSessionId(user);
        }

        public User GetUserDetails(User user)
        {
            return _userRepository.GetUserDetails(user);
        }

        public void EditProfileDetails(User user)
        {
            _userRepository.EditProfileDetails(user);
        }

        public IEnumerable<User> GetSearchResult(string Searchterm)
        {
            return _userRepository.GetSearchResult(Searchterm);
        }

        public IEnumerable<User> GetFollowers(User user)
        {
            return _userRepository.GetFollowers(user);
        }

        public int CheckDublicate(User user)
        {
            int UserCount = _userRepository.CheckDublicate(user);
            return UserCount;
        }

        public int VerifyUser(User user)
        {
            int UserCount = _userRepository.VerifyUser(user);
            return UserCount;
        }

        public bool CheckIfProfileExists(int Id)
        {
            bool DoesExist = _userRepository.CheckIfProfileExists(Id);
            return DoesExist;
        }
    }
}

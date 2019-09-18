using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;

namespace SocialNetwork.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User RegisterUser(User user)
        {
            return _userRepository.RegisterUser(user);
        }

        public User GetSessionId(User user)
        {
            return _userRepository.GetSessionId(user);
        }

        public User GetUserDetails(User user)
        {
            return _userRepository.GetUserDetails(user);
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
    }
}

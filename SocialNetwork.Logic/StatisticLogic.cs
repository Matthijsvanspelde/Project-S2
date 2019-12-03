using SocialNetwork.DAL.IRepositories;
using System;

namespace SocialNetwork.Logic.ILogic
{
    public class StatisticLogic : IStatisticLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public StatisticLogic(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public double AveragePostsPerUser()
        {
            double userCount = _userRepository.GetUserCount();
            double postCount = _postRepository.GetPostCount();
            double averagePostsPerUser = postCount / userCount;           
            return Math.Round(averagePostsPerUser, 3);
        }

        public double AverageFollowersPerUser()
        {
            double userCount = _userRepository.GetUserCount();
            double followerCount = _userRepository.GetFollowerCount();
            double averageFollowersPerUser = followerCount / userCount;
            return Math.Round(averageFollowersPerUser, 3);
        }
    }
}

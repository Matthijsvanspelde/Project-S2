using SocialNetwork.DAL.IRepositories;

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

        public float AveragePostsPerUser()
        {
            float userCount = _userRepository.GetUserCount();
            float postCount = _postRepository.GetPostCount();
            float averagePostsPerUser = postCount / userCount;
            return averagePostsPerUser;
        }
    }
}

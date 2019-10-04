using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostRepository _postRepository;

        public PostLogic(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void SetPost(Post post, User user)
        {            
            _postRepository.SetPost(post, user);
        }

        public void LikePost(Post post, User user)
        {
            _postRepository.LikePost(post, user);
        }

        public int CheckDublicateLike(Post post, User user)
        {
            return _postRepository.CheckDublicateLike(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _postRepository.GetPost(user);
        }

        public IEnumerable<Post> GetFollowingPosts(User user)
        {
            return _postRepository.GetFollowingPosts(user);
        }
    }
}

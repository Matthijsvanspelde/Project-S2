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

        public bool SetPost(Post post, User user)
        {            
            return _postRepository.SetPost(post, user);
        }

        public void LikePost(Post post, User user)
        {
            _postRepository.LikePost(post, user);
        }

        public bool AlreadyLiked(Post post, User user)
        {
            return _postRepository.AlreadyLiked(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _postRepository.GetPost(user);
        }

        public IEnumerable<Post> GetFollowingPosts(User user)
        {
            return _postRepository.GetFollowingPosts(user);
        }

        public void DeletePost(Post post, User user)
        {
            _postRepository.DeletePost(post, user);
        }
    }
}

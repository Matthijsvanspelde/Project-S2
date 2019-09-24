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

        public Post SetPost(Post post, User user)
        {            
            return _postRepository.SetPost(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _postRepository.GetPost(user);
        }
    }
}

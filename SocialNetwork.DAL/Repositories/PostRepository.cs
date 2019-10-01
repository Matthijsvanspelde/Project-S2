using SocialNetwork.DAL.IContexts;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IPostContext _IPostContext;

        public PostRepository(IPostContext IUserContext)
        {
            _IPostContext = IUserContext;
        }

        public void SetPost(Post post, User user)
        {
            _IPostContext.SetPost(post, user);
        }

        public void LikePost(Post post, User user)
        {
            _IPostContext.LikePost(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _IPostContext.GetPost(user);
        }

        public IEnumerable<Post> GetFollowingPosts(User user)
        {
            return _IPostContext.GetFollowingPosts(user);
        }
    }
}

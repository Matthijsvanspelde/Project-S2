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

        public bool SetPost(Post post, User user)
        {
            return _IPostContext.SetPost(post, user);
        }

        public void LikePost(Post post, User user)
        {
            _IPostContext.LikePost(post, user);
        }

        public bool AlreadyLiked(Post post, User user)
        {
            return _IPostContext.AlreadyLiked(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _IPostContext.GetPost(user);
        }

        public IEnumerable<Post> GetFollowingPosts(User user)
        {
            return _IPostContext.GetFollowingPosts(user);
        }

        public void DeletePost(Post post, User user)
        {
            _IPostContext.DeletePost(post, user);
        }

        public int GetPostCount()
        {
            int PostCount = _IPostContext.GetPostCount();
            return PostCount;
        }
    }
}

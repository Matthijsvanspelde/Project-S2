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

        public Post SetPost(Post post, User user)
        {
            return _IPostContext.SetPost(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _IPostContext.GetPost(user);
        }
    }
}

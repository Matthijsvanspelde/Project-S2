using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface IPostContext
    {
        void SetPost(Post post, User user);
        IEnumerable<Post> GetPost(User user);
    }
}

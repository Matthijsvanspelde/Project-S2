using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface IPostContext
    {
        void SetPost(Post post, User user);
        void LikePost(Post post, User user);
        int CheckDublicateLike(Post post, User user);
        IEnumerable<Post> GetPost(User user);
        IEnumerable<Post> GetFollowingPosts(User user);
        void DeletePost(Post post, User user);
    }
}

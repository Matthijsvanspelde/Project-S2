using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IPostRepository
    {
        void SetPost(Post post, User user);
        void LikePost(Post post, User user);
        int CheckDublicateLike(Post post, User user);
        IEnumerable<Post> GetPost(User user);
        IEnumerable<Post> GetFollowingPosts(User user);
    }
}

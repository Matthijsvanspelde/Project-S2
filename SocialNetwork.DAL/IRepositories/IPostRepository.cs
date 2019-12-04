using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IPostRepository
    {
        bool SetPost(Post post, User user);
        void LikePost(Post post, User user);
        bool AlreadyLiked(Post post, User user);
        IEnumerable<Post> GetPost(User user);
        IEnumerable<Post> GetFollowingPosts(User user);
        void DeletePost(Post post, User user);
        int GetPostCount();
    }
}

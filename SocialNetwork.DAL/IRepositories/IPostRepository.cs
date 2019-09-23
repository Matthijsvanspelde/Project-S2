using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IPostRepository
    {
        Post SetPost(Post post, User user);
        IEnumerable<Post> GetPost(User user);
    }
}

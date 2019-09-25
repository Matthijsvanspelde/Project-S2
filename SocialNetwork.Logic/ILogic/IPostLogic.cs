using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IPostLogic
    {
        void SetPost(Post post, User user);
        IEnumerable<Post> GetPost(User user);
    }
}

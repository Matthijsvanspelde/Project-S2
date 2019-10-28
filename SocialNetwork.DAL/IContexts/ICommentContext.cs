using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface ICommentContext
    {
        void SetComment(Comment comment, Post post, User user);
        IEnumerable<Comment> GetComment(User user);
    }
}

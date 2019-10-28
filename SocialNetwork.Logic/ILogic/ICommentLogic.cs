using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface ICommentLogic
    {
        void SetComment(Comment comment, Post post, User user);
        IEnumerable<Comment> GetComment(User user);
    }
}

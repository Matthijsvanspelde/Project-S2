using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface ICommentRepository
    {
        void SetComment(Comment comment, Post post, User user);
        IEnumerable<Comment> GetComment(User user);
    }
}

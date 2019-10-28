using SocialNetwork.DAL.IContexts;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ICommentContext _commentContext;

        public CommentRepository(ICommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        public void SetComment(Comment comment, Post post, User user)
        {
            _commentContext.SetComment(comment, post, user);
        }

        public IEnumerable<Comment> GetComment(User user)
        {
            return _commentContext.GetComment(user);
        }
    }
}

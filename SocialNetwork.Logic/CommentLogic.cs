using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic
{
    public class CommentLogic: ICommentLogic
    {
        private readonly ICommentRepository _commentRepository;

        public CommentLogic(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void SetComment(Comment comment, Post post, User user)
        {
            _commentRepository.SetComment(comment, post, user);
        }

        public IEnumerable<Comment> GetComment(User user)
        {
            return _commentRepository.GetComment(user);
        }
    }
}

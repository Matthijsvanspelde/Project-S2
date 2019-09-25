﻿using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostRepository _postRepository;

        public PostLogic(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void SetPost(Post post, User user)
        {            
            _postRepository.SetPost(post, user);
        }

        public IEnumerable<Post> GetPost(User user)
        {
            return _postRepository.GetPost(user);
        }
    }
}
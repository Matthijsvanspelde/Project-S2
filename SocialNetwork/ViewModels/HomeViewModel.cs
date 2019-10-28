using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.ViewModels
{
    public class HomeViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

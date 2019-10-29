using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public DateTime Posted { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

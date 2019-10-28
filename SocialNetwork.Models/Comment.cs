using System;

namespace SocialNetwork.Models
{
    public class Comment
    {
        public string Message { get; set; }
        public DateTime Posted { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
    }
}

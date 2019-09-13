﻿using System;

namespace SocialNetwork.Models
{
    public class Post
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int Likes { get; set; }
        public DateTime Posted { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
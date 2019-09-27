using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.ViewModels
{
    public class PostViewModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Message { get; set; }

        public int Likes { get; set; }
        public DateTime Posted { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
    }
}

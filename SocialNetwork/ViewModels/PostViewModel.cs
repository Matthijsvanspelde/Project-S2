using System;
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
        [Required]
        public string Image { get; set; }
        public int Likes { get; set; }
        public DateTime Posted { get; set; }
    }
}

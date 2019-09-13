using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Firstname { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

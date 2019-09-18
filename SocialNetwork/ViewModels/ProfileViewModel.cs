using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Firstname { get; set; }

        [RegularExpression("^[a-zA-Z ]*$")]
        public string Middlename { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        //List van maken?
        public string Country { get; set; }

        //List van maken?
        public string City { get; set; }
    }
}

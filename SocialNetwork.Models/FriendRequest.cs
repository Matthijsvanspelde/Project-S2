using System;

namespace SocialNetwork.Models
{
    public class FriendRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Recieved { get; set; }
    }
}

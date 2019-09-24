using System;

namespace SocialNetwork.Models
{
    public class FriendRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int SenderId { get; set; }
        public int RevieverId { get; set; }
        public DateTime Recieved { get; set; }
    }
}

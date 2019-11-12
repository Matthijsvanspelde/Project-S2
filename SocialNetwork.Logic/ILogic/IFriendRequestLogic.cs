using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IFriendRequestLogic
    {
        void SendFriendRequest(FriendRequest friendRequest);
        void DeleteFriendRequest(FriendRequest friendRequest);
        void AcceptFriendRequest(FriendRequest friendRequest);
        IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest);
        bool DoesFriendRequestExist(FriendRequest friendRequest);
        bool IsFollowing(FriendRequest friendRequest);
    }
}

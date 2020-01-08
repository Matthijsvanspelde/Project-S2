using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface IFriendRequestContext
    {
        bool SendFriendRequest(FriendRequest friendRequest);
        void DeleteFriendRequest(FriendRequest friendRequest);
        void AcceptFriendRequest(FriendRequest friendRequest);
        IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest);
        bool DoesFriendRequestExist(FriendRequest friendRequest);
        bool IsFollowing(FriendRequest friendRequest);
    }
}

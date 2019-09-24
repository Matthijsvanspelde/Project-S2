using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IContexts
{
    public interface IFriendRequestContext
    {
        FriendRequest SendFriendRequest(FriendRequest friendRequest);
        IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

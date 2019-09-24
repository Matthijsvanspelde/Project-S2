using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic.ILogic
{
    public interface IFriendRequestLogic
    {
        FriendRequest SendFriendRequest(FriendRequest friendRequest);
        IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

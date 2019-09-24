using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IFriendRequestRepository
    {
        FriendRequest SendFriendRequest(FriendRequest friendRequest);
        IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

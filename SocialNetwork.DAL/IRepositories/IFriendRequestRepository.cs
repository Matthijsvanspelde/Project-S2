using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IFriendRequestRepository
    {
        void SendFriendRequest(FriendRequest friendRequest);
        void DeleteFriendRequest(FriendRequest friendRequest);
        void AcceptFriendRequest(FriendRequest friendRequest);
        IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

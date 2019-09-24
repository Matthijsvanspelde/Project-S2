using SocialNetwork.Models;

namespace SocialNetwork.DAL.IRepositories
{
    public interface IFriendRequestRepository
    {
        FriendRequest SendFriendRequest(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

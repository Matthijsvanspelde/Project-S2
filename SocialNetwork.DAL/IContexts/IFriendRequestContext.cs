using SocialNetwork.Models;

namespace SocialNetwork.DAL.IContexts
{
    public interface IFriendRequestContext
    {
        FriendRequest SendFriendRequest(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

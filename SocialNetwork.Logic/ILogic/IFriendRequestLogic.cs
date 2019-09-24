using SocialNetwork.Models;

namespace SocialNetwork.Logic.ILogic
{
    public interface IFriendRequestLogic
    {
        FriendRequest SendFriendRequest(FriendRequest friendRequest);
        int CheckDublicateFriendRequest(FriendRequest friendRequest);
    }
}

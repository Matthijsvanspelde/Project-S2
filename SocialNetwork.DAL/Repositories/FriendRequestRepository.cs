using SocialNetwork.DAL.IContexts;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Models;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly IFriendRequestContext _IFriendRequestContext;

        public FriendRequestRepository(IFriendRequestContext IUserContext)
        {
            _IFriendRequestContext = IUserContext;
        }

        public FriendRequest SendFriendRequest(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.SendFriendRequest(friendRequest);
        }

        public int CheckDublicateFriendRequest(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.CheckDublicateFriendRequest(friendRequest);
        }
    }
}

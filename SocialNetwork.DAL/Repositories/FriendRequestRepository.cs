using SocialNetwork.DAL.IContexts;
using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly IFriendRequestContext _IFriendRequestContext;

        public FriendRequestRepository(IFriendRequestContext IUserContext)
        {
            _IFriendRequestContext = IUserContext;
        }

        public void SendFriendRequest(FriendRequest friendRequest)
        {
            _IFriendRequestContext.SendFriendRequest(friendRequest);
        }

        public int CheckDublicateFriendRequest(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.CheckDublicateFriendRequest(friendRequest);
        }

        public IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.GetFriendRequests(friendRequest);
        }
    }
}

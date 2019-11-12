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

        public void DeleteFriendRequest(FriendRequest friendRequest)
        {
            _IFriendRequestContext.DeleteFriendRequest(friendRequest);
        }

        public void AcceptFriendRequest(FriendRequest friendRequest)
        {
            _IFriendRequestContext.AcceptFriendRequest(friendRequest);
        }

        public bool DoesFriendRequestExist(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.DoesFriendRequestExist(friendRequest);
        }

        public bool IsFollowing(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.IsFollowing(friendRequest);
        }

        public IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest)
        {
            return _IFriendRequestContext.GetFriendRequests(friendRequest);
        }
    }
}

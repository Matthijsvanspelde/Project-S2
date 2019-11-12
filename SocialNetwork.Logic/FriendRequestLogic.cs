using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Logic
{
    public class FriendRequestLogic : IFriendRequestLogic
    {
        private readonly IFriendRequestRepository _FriendRequestRepository;

        public FriendRequestLogic(IFriendRequestRepository FriendRequestRepository)
        {
            _FriendRequestRepository = FriendRequestRepository;
        }

        public void SendFriendRequest(FriendRequest friendRequest)
        {
            _FriendRequestRepository.SendFriendRequest(friendRequest);
        }

        public void DeleteFriendRequest(FriendRequest friendRequest)
        {
            _FriendRequestRepository.DeleteFriendRequest(friendRequest);
        }

        public void AcceptFriendRequest(FriendRequest friendRequest)
        {
            _FriendRequestRepository.AcceptFriendRequest(friendRequest);
        }

        public bool DoesFriendRequestExist(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.DoesFriendRequestExist(friendRequest);
        }

        public bool IsFollowing(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.IsFollowing(friendRequest);
        }

        public IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.GetFriendRequests(friendRequest);
        }
    }
}

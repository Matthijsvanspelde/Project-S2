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

        public int CheckDublicateFriendRequest(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.CheckDublicateFriendRequest(friendRequest);
        }

        public IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.GetFriendRequests(friendRequest);
        }
    }
}

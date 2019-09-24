using SocialNetwork.DAL.IRepositories;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;

namespace SocialNetwork.Logic
{
    public class FriendRequestLogic : IFriendRequestLogic
    {
        private readonly IFriendRequestRepository _FriendRequestRepository;

        public FriendRequestLogic(IFriendRequestRepository FriendRequestRepository)
        {
            _FriendRequestRepository = FriendRequestRepository;
        }

        public FriendRequest SendFriendRequest(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.SendFriendRequest(friendRequest);
        }

        public int CheckDublicateFriendRequest(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.CheckDublicateFriendRequest(friendRequest);
        }
    }
}

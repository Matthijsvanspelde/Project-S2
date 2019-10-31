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

        public bool IsRequested(FriendRequest friendRequest)
        {
            bool Added;
            if (CheckDublicateFriendRequest(friendRequest) == 0)
            {
                Added = false;
            }
            else
            {
                Added = true;
            }
            return Added;
        }

        public bool IsFollowing(FriendRequest friendRequest)
        {
            bool Following;
            if (CheckIfFollowing(friendRequest) == 0)
            {
                Following = false;
            }
            else
            {
                Following = true;
            }
            return Following;
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

        public int CheckDublicateFriendRequest(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.CheckDublicateFriendRequest(friendRequest);
        }

        public int CheckIfFollowing(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.CheckIfFollowing(friendRequest);
        }

        public IEnumerable<FriendRequest> GetFriendRequests(FriendRequest friendRequest)
        {
            return _FriendRequestRepository.GetFriendRequests(friendRequest);
        }
    }
}

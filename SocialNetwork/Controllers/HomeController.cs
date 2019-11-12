using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IFriendRequestLogic _friendRequestLogic;
        private readonly IPostLogic _postLogic;
        private readonly ICommentLogic _commentLogic;

        public HomeController(IUserLogic userLogic, IFriendRequestLogic friendRequestLogic, IPostLogic postLogic, ICommentLogic commentLogic)
        {
            _userLogic = userLogic;
            _friendRequestLogic = friendRequestLogic;
            _postLogic = postLogic;
            _commentLogic = commentLogic;
        }

        public IActionResult NewsFeed(User user)
        {            
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Post post = new Post();
                user.Id = (int)HttpContext.Session.GetInt32("Id");
                HomeViewModel homeViewModel = new HomeViewModel();

                //TODO: Haalt niet de juiste comments bij de juiste posts op.
                homeViewModel.Comments = new List<Comment>();
                homeViewModel.Comments.AddRange(_commentLogic.GetComment(user));

                homeViewModel.Posts = new List<Post>();
                homeViewModel.Posts.AddRange(_postLogic.GetFollowingPosts(user));
                return View(homeViewModel);
            }            
        }

        public IActionResult FriendRequests(FriendRequest friendRequest)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                friendRequest.RecieverId = (int)HttpContext.Session.GetInt32("Id");
                FriendRequestViewModel friendRequestViewModel = new FriendRequestViewModel();
                friendRequestViewModel.friendRequests = new List<FriendRequest>();
                friendRequestViewModel.friendRequests.AddRange(_friendRequestLogic.GetFriendRequests(friendRequest));
                return View(friendRequestViewModel);
            }           
        }

        public IActionResult LikePost(int PostId)
        {
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            Post post = new Post();
            post.PostId = PostId;
            if (_postLogic.AlreadyLiked(post, user) == false)
            {
                _postLogic.LikePost(post, user);
            }            
            return RedirectToAction("NewsFeed", "Home");
        }

        public IActionResult SetComment(Comment comment, Post post)
        {
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            comment.Posted = DateTime.Now;
            _commentLogic.SetComment(comment, post, user);
            return RedirectToAction("NewsFeed", "Home");
        }

        public IActionResult DenyFriendRequest(int SenderId)
        {
            FriendRequest friendRequest = new FriendRequest();
            friendRequest.RecieverId = (int)HttpContext.Session.GetInt32("Id");
            friendRequest.SenderId = SenderId;
            _friendRequestLogic.DeleteFriendRequest(friendRequest);
            return RedirectToAction("FriendRequests", "Home");
        }

        public IActionResult AcceptFriendRequest(int SenderId)
        {
            FriendRequest friendRequest = new FriendRequest();
            friendRequest.RecieverId = (int)HttpContext.Session.GetInt32("Id");
            friendRequest.SenderId = SenderId;
            friendRequest.Recieved = DateTime.Now;
            _friendRequestLogic.AcceptFriendRequest(friendRequest);
            return RedirectToAction("FriendRequests", "Home");
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;
using System.Collections.Generic;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IFriendRequestLogic _friendRequestLogic;

        public HomeController(IUserLogic userLogic, IFriendRequestLogic friendRequestLogic)
        {
            _userLogic = userLogic;
            _friendRequestLogic = friendRequestLogic;
        }

        public IActionResult Timeline(User user)
        {            
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
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
                friendRequest.RevieverId = (int)HttpContext.Session.GetInt32("Id");
                FriendRequestViewModel friendRequestViewModel = new FriendRequestViewModel();
                friendRequestViewModel.friendRequests = new List<FriendRequest>();
                friendRequestViewModel.friendRequests.AddRange(_friendRequestLogic.GetFriendRequests(friendRequest));
                return View(friendRequestViewModel);
            }           
        }
    }
}
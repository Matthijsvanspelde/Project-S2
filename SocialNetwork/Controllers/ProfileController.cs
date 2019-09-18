using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;
using System;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserLogic _userLogic;

        public ProfileController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public IActionResult Overview(User user)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                user.Id = (int)HttpContext.Session.GetInt32("Id");
                _userLogic.GetUserDetails(user);
                ProfileViewModel profileViewModel = new ProfileViewModel()
                {
                    Firstname = user.Firstname,
                    Middlename = user.Middlename,
                    Lastname = user.Lastname,
                    Birthdate = user.Birthdate,
                    Country = user.Country,
                    City = user.City
                };
                return View(profileViewModel);
            }            
        }

        public IActionResult Edit(User user)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                user.Id = (int)HttpContext.Session.GetInt32("Id");
                _userLogic.GetUserDetails(user);
                ProfileViewModel profileViewModel = new ProfileViewModel()
                {
                    Firstname = user.Firstname,
                    Middlename = user.Middlename,
                    Lastname = user.Lastname,
                    Birthdate = user.Birthdate,
                    Country = user.Country,
                    City = user.City
                };
                return View(profileViewModel);
            }            
        }

        public IActionResult EditProfile(User user)
        {
            user.Id = (int)HttpContext.Session.GetInt32("Id");
            _userLogic.EditProfileDetails(user);
            return RedirectToAction("Overview", "Profile");
        }

        public IActionResult GetProfileDFriends()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetProfilePosts()
        {
            throw new NotImplementedException();
        }
    }
}
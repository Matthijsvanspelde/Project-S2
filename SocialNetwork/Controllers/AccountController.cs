using Microsoft.AspNetCore.Mvc;
using System;

namespace SocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LoginUser()
        {
            throw new NotImplementedException();
        }

        public IActionResult RegisterUser()
        {
            throw new NotImplementedException();
        }

        public IActionResult LogoutUser()
        {
            throw new NotImplementedException();
        }
    }
}
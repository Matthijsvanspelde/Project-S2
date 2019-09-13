using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;
using System;

namespace SocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserLogic _userLogic;

        public AccountController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                ErrorMessage = "",
            };
            return View(loginViewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult VerifyUser(User user)
        {
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                ErrorMessage = "",
            };
            if (_userLogic.VerifyUser(user) == 1)
            {
                user = _userLogic.GetUser(user);
                HttpContext.Session.SetInt32("Id", user.Id);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                loginViewModel.ErrorMessage = "Username and password combination is not valid!";
                return View("Login", loginViewModel);
            }
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
                _userLogic.RegisterUser(user);
                return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public JsonResult DoesUserNameExist(User user)
        {
            if (_userLogic.CheckDublicate(user) >= 1)
            {
                return Json(user == null);
            }
            return Json(user != null);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home", "Account");
        }
    }
}
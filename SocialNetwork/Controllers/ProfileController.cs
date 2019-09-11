using Microsoft.AspNetCore.Mvc;
using System;

namespace SocialNetwork.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            throw new NotImplementedException();
        }
    }
}
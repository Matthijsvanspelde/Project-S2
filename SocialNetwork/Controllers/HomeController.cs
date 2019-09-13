using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic _userLogic;

        public HomeController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public IActionResult Home(User user)
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
    }
}
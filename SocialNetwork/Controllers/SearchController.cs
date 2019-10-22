using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUserLogic _userLogic;
        private readonly IPostLogic _postLogic;
        private readonly IProfilePictureLogic _profilePictureLogic;

        public SearchController(IUserLogic userLogic, IPostLogic postLogic, IProfilePictureLogic profilePictureLogic)
        {
            _userLogic = userLogic;
            _postLogic = postLogic;
            _profilePictureLogic = profilePictureLogic;
        }

        public IActionResult Search()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                SearchViewModel searchViewModel = new SearchViewModel()
                {
                    SearchResult = new List<User>(),
                    SearchError = ""
                };
                return View(searchViewModel);
            }
        }

        public IActionResult GetSearchedUsers(string Searchterm)
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            if (Searchterm == null)
            {
                searchViewModel.SearchResult = new List<User>();
                searchViewModel.SearchError = "The Search field is required.";
                return View("Search", searchViewModel);
            }
            else
            {
                searchViewModel.SearchResult = new List<User>();
                User user = new User();
                searchViewModel.SearchResult.AddRange(_userLogic.GetSearchResult(Searchterm));
                var ResultCount = searchViewModel.SearchResult.Count();
                searchViewModel.SearchError = "About " + ResultCount + " matching result(s).";
                return View("Search", searchViewModel);
            }                     
        }      
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.Models;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUserLogic _userLogic;

        public SearchController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
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

        public IActionResult Profile()
        {
            return View();
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
                
                searchViewModel.SearchResult.AddRange(_userLogic.GetSearchResult(Searchterm));
                var ResultCount = searchViewModel.SearchResult.Count();
                searchViewModel.SearchError = "About " + ResultCount + " matching result(s).";
                return View("Search", searchViewModel);
            }                     
        }   
    }
}
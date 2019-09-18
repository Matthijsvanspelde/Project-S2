using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.ViewModels
{
    public class SearchViewModel
    {
        public List<User> SearchResult { get; set; }
        public string SearchError { get; set; }
    }
}

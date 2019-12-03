using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Logic.ILogic;
using SocialNetwork.ViewModels;

namespace SocialNetwork.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticLogic _statisticLogic;

        public StatisticsController(IStatisticLogic statisticLogic)
        {
            _statisticLogic = statisticLogic;
        }

        public IActionResult Index()
        {
            StatisticsViewModel statisticsViewModel = new StatisticsViewModel
            {
                AveragePostPerUser = _statisticLogic.AveragePostsPerUser(),
                AverageFollowersPerUser = _statisticLogic.AverageFollowersPerUser(),
            };
            return View(statisticsViewModel);
        }
    }
}
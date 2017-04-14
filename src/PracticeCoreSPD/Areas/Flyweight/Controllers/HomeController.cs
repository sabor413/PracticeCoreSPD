using Microsoft.AspNetCore.Mvc;
using PracticeCoreSPD.Areas.Flyweight.Core;

namespace PracticeCoreSPD.Areas.Flyweight.Controllers
{
    [Area("Flyweight")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowStats(string host)
        {
            WebsiteStatsFactory factory = new WebsiteStatsFactory();
            WebsiteStats stats = (WebsiteStats) factory[host];
            if (stats == null)
            {
                ViewBag.Message = "Invalid Host Name!";
                return View("Index");
            }
            else
            {
                return View(stats);
            }
        }
    }
}

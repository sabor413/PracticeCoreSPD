using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreSPD.Areas.Facade.Core;

namespace PracticeCoreSPD.Areas.Facade.Controllers
{
    [Area("Facade")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string isbn)
        {
            PriceComparer comparer = new PriceComparer();
            List<Book> books = comparer.Compare(isbn);
            return View("Results", books);
        }
    }
}

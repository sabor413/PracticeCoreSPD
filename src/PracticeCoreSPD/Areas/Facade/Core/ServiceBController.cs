using System.Linq;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeCoreSPD.Areas.Facade.Core
{
    [Route("api/[controller]")]
    public class ServiceBController : Controller
    {
        // GET: api/values
        [HttpGet("{isbn}")]
        public Book Get(string isbn)
        {
            using (AppDbBooks db = new AppDbBooks())
            {
                var query = from b in db.Books
                            where b.ISBN == isbn && b.Source == "Book Store 2"
                            select b;
                return query.SingleOrDefault();
            }
        }
    }
}

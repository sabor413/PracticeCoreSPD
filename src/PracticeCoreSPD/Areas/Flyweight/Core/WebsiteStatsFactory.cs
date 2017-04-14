using System.Collections.Generic;
using System.Linq;

namespace PracticeCoreSPD.Areas.Flyweight.Core
{
    public class WebsiteStatsFactory
    {
        private static Dictionary<string, WebsiteStats> dictionary = new Dictionary<string, WebsiteStats>();

        public IWebsiteStats this[string host]
        {
            get
            {
                if (!dictionary.ContainsKey(host))
                {
                    using (AppDbStats db = new AppDbStats())
                    {
                        var query = from stats in db.WebsiteStats
                            where stats.Host == host
                            select stats;
                        dictionary[host] = query.FirstOrDefault();
                    }
                }
                return dictionary[host];
            }
        }
    }
}

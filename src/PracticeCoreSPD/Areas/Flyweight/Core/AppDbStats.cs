using System.Data.Entity;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD.Areas.Flyweight.Core
{
    public class AppDbStats : DbContext
    {
        public AppDbStats() : base(AppSettings.ConnectionString)
        { }
        
        public DbSet<WebsiteStats> WebsiteStats { get; set; }
    }
}

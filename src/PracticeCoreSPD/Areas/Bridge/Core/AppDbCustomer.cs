using System.Data.Entity;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD.Areas.Bridge.Core
{
    public class AppDbCustomer : DbContext
    {
        public AppDbCustomer() : base(AppSettings.ConnectionString)
        { }

        public DbSet<Customer> Customers { get; set; }
    }
}

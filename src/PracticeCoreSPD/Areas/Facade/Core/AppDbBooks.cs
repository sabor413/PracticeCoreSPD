using System.Data.Entity;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD.Areas.Facade.Core
{
    public class AppDbBooks : DbContext
    {
        public AppDbBooks() : base(AppSettings.ConnectionString)
        { }
        public DbSet<Book> Books { get; set; }
    }
}

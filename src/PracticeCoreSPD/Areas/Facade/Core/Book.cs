using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeCoreSPD.Areas.Facade.Core
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string Source { get; set; }
        public string PurchaseUrl { get; set; }
    }
}

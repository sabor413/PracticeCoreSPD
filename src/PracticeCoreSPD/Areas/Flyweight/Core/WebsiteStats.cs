using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeCoreSPD.Areas.Flyweight.Core
{
    [Table("WebsiteStats")]
    public class WebsiteStats : IWebsiteStats
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Host { get; set; }
        [Required]
        public int PageViews { get; set; }
        [Required]
        public int SiteVisits { get; set; }
        [Required]
        public string TopKeywords { get; set; }
        [Required]
        public int Bandwidth { get; set; }
        public int GetActiveUsers()
        {
            return new Random().Next(100, 10000);
        }
    }
}

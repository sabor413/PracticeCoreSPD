using System.Collections.Generic;

namespace PracticeCoreSPD.Areas.Composite.Core
{
    public class Menu : IMenuComponent
    {
        public string Text { get; set; }
        public string NavigateUrl { get; set; }
        public List<IMenuComponent> Children { get; set; }
        public bool OpenInNewWindow { get; set; }
    }
}

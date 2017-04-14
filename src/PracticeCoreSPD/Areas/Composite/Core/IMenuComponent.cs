using System.Collections.Generic;

namespace PracticeCoreSPD.Areas.Composite.Core
{
    public interface IMenuComponent
    {
        string Text { get; set; }
        string NavigateUrl { get; set; }
        List<IMenuComponent> Children { get; set; }
    }
}

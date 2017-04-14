using System.Collections.Generic;
using System.Drawing;

namespace PracticeCoreSPD.Areas.Adapter.Core
{
    public interface IChart
    {
        string Title { get; set; }
        List<string> XData { get; set; }
        List<int> YData { get; set; }
        List<Color> Colors { get; set; } 
        Bitmap GenerateChart();
    }
}

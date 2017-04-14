using System.Collections.Generic;
using System.Drawing;

namespace PracticeCoreSPD.Areas.Adapter.Core
{
    public class MyChartAdapter : IChart
    {
        public string Title { get; set; }
        public List<string> XData { get; set; }
        public List<int> YData { get; set; }
        public List<Color> Colors { get; set; }
        public Bitmap GenerateChart()
        {
            ThirdPartyChartGenerator chart = new ThirdPartyChartGenerator();
            return chart.DrawChart(Title, XData, YData, Colors);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreSPD.Areas.Adapter.Core;

namespace PracticeCoreSPD.Areas.Adapter.Controllers
{
    [Area("Adapter")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            GetImageOwnComponent();
            GetImageThirdPartyComponent();
            return View();
        }

        public void GetImageOwnComponent()
        {
            IChart chart = new MyChartGenerator();

            chart.Title = "Hours per day";

            List<string> xdata = new List<string>();
            xdata.Add("Mon");
            xdata.Add("Tue");
            xdata.Add("Wed");
            xdata.Add("Thu");
            xdata.Add("Fri");
            xdata.Add("Sat");
            xdata.Add("Sun");

            List<int> ydata = new List<int>();
            ydata.Add(12);
            ydata.Add(7);
            ydata.Add(4);
            ydata.Add(10);
            ydata.Add(3);
            ydata.Add(11);
            ydata.Add(5);

            List<Color> colordata = new List<Color>();
            colordata.Add(Color.Red);
            colordata.Add(Color.Blue);
            colordata.Add(Color.Yellow);
            colordata.Add(Color.Orange);
            colordata.Add(Color.Green);
            colordata.Add(Color.DarkGoldenrod);
            colordata.Add(Color.MediumOrchid);

            chart.XData = xdata;
            chart.YData = ydata;
            chart.Colors = colordata;
            Bitmap bmp = chart.GenerateChart();
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\GetImageOwnComponent.png");
            bmp.Save(path, ImageFormat.Png);
        }

        public void GetImageThirdPartyComponent()
        {
            IChart chart = new MyChartAdapter();

            chart.Title = "Hours per day";

            List<string> xdata = new List<string>();
            xdata.Add("Mon");
            xdata.Add("Tue");
            xdata.Add("Wed");
            xdata.Add("Thu");
            xdata.Add("Fri");
            xdata.Add("Sat");
            xdata.Add("Sun");

            List<int> ydata = new List<int>();
            ydata.Add(12);
            ydata.Add(7);
            ydata.Add(4);
            ydata.Add(10);
            ydata.Add(3);
            ydata.Add(11);
            ydata.Add(5);

            List<Color> colordata = new List<Color>();
            colordata.Add(Color.Red);
            colordata.Add(Color.Blue);
            colordata.Add(Color.Yellow);
            colordata.Add(Color.Orange);
            colordata.Add(Color.Green);
            colordata.Add(Color.DarkGoldenrod);
            colordata.Add(Color.MediumOrchid);

            chart.XData = xdata;
            chart.YData = ydata;
            chart.Colors = colordata;
            Bitmap bmp = chart.GenerateChart();
            string path = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\GetImageThirdPartyComponent.png");
            bmp.Save(path, ImageFormat.Png);
        }
    }
}

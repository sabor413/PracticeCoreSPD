using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PracticeCoreSPD.Areas.Decorator.Core;

namespace PracticeCoreSPD.Areas.Decorator.Controllers
{
    [Area("Decorator")]
    public class HomeController : Controller
    {
        private IHostingEnvironment hostingEnvironment;

        public HomeController(IHostingEnvironment env)
        {
            this.hostingEnvironment = env;
        }

        public IActionResult GetImageOriginal()
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\Computer.png");
            IPhoto photo = new Photo(fileName);
            Bitmap bmp = photo.GetPhoto();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            /* bmp.Save(fileName, ImageFormat.Png); */
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

        public IActionResult GetImageWatermarked()
        {
            string fileName = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\ComputerWM.png");
            IPhoto photo = new Photo(fileName);
            WatermarkDecorator decorator = new WatermarkDecorator(photo, "Copyright (C) 2015.");
            Bitmap bmp = decorator.GetPhoto();
            MemoryStream stream = new MemoryStream();
            bmp.Save(stream, ImageFormat.Png);
            /* bmp.Save(fileName, ImageFormat.Png); */
            byte[] data = stream.ToArray();
            stream.Close();
            return File(data, "image/png");
        }

        public IActionResult Index()
        {
            GetImageOriginal();
            GetImageWatermarked();
            return View();
        }
    }
}

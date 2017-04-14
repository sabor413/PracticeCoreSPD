using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using NuGet.Protocol.Core.v3;

namespace PracticeCoreSPD.Areas.Decorator.Core
{
    public class WatermarkDecorator : DecoratorBase
    {
        private string watermarkText;
        public WatermarkDecorator(IPhoto photo, string watermark) : base(photo)
        {
            this.watermarkText = watermark;
        }

        public override Bitmap GetPhoto()
        {
            Bitmap bmp = base.GetPhoto();
            Graphics g = Graphics.FromImage(bmp);
            Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };
            float x = (float)bmp.Width / 2;
            float y = (float)bmp.Height / 2;
            g.DrawString(watermarkText, font, Brushes.Black, x, y, sf);
            g.Save();

            #region Trying Another Way
            //Bitmap bmp = base.GetPhoto();
            //using (bmp)
            //{
            //    using (Graphics g = Graphics.FromImage(bmp))
            //    {
            //        Font font = new Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel);
            //        StringFormat sf = new StringFormat
            //        {
            //            LineAlignment = StringAlignment.Center,
            //            Alignment = StringAlignment.Center
            //        };
            //        float x = (float)bmp.Width / 2;
            //        float y = (float)bmp.Height / 2;
            //        g.DrawString(watermarkText, font, Brushes.Black, x, y, sf);
            //        g.Save();
            //    }
            //    //string fileName = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\ComputerWM.png");
            //    //bmp.Save(fileName, ImageFormat.Png);
            //}
            #endregion

            return bmp;
        }
    }
}

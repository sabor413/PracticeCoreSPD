using System;
using System.IO;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD.Areas.Bridge.Core
{
    public class XmlErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            msg = $"<error><message>{msg}</message><timestamp>{DateTime.Now}</timestamp></error>";
            File.AppendAllText(AppSettings.LogFileFolder + "/errorlog.xml", msg);
        }
    }
}

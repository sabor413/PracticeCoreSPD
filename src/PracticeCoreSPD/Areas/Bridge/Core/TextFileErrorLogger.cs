using System;
using System.IO;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD.Areas.Bridge.Core
{
    public class TextFileErrorLogger : IErrorLogger
    {
        public void Log(string msg)
        {
            msg += $" [{DateTime.Now}]";
            msg += "\r\n";
            File.AppendAllText(AppSettings.LogFileFolder + "/errorlog.txt", msg);
        }
    }
}

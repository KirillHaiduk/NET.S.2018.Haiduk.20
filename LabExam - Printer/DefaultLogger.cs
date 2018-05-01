using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    public class DefaultLogger : ILogger
    {
        public void Log(string message)
        {
            File.AppendText("log.txt").Write(message);
        }
    }
}

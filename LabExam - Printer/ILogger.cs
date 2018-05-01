using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    // Interface for possibility of adding different loggers
    public interface ILogger
    {
        void Log(string message);
    }
}

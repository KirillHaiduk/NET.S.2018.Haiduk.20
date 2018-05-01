using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    // Class for describing event of printing
    public sealed class PrintEventArgs : EventArgs
    {
        private string printingArg;

        public PrintEventArgs(string arg)
        {
            this.printingArg = arg;
        }

        public string PrintingArg => printingArg;
    }
}

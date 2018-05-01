using System;
using System.IO;

namespace LabExam
{
    // Impliments Printer for further extension or adding new printers
    internal class EpsonPrinter : Printer
    {
        private string model = "Epson";

        public EpsonPrinter(string name, string model) : base(name, model)
        {            
        }              
    }
}
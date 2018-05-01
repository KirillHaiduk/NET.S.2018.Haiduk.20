using System;
using System.IO;

namespace LabExam
{
    // Impliments Printer for further extension or adding new printers
    internal class CanonPrinter : Printer
    {
        private string model = "Canon";

        public CanonPrinter(string name, string model) : base(name, model)
        {
        }                 
    }
}
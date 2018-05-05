using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Inherited from Printer for making custom Print method
    /// </summary>
    internal class CanonPrinter : Printer
    {
        public CanonPrinter(string name, string model) : base(name, model)
        {
            this.model = "Canon";
        }

        protected override void SimulatePrinting(Stream stream)
        {
            Console.Write($"Canon {this.Name} is printing...");
            for (int i = 0; i < stream.Length; i++)
            {
                Console.WriteLine(stream.ReadByte());
                Console.ReadKey();
            }
        }
    }
}
using System;
using System.IO;

namespace LabExam

{
    // Modified into abstract class for common method and properties
    public abstract class Printer
    {
        protected string name;
        protected string model;

        public Printer(string name, string model)
        {
            this.name = name;
            this.model = model;           
        }

        public string Name => name;

        public string Model => model;

        public void Print(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                for (int i = 0; i < fileStream.Length; i++)
                {
                    // simulate printing
                    Console.WriteLine(fileStream.ReadByte());
                }
            }
        }        

        // Description of printing event
        public event EventHandler<PrintEventArgs> Printing = delegate { };

        protected virtual void OnPrinted(PrintEventArgs e)
        {
            EventHandler<PrintEventArgs> temp = Printing;
            Printing?.Invoke(this, e);
        }

        public void SimulatePrinting(string printArg)
        {
            OnPrinted(new PrintEventArgs(printArg));
        }
    }
}
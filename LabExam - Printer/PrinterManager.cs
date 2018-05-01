using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{    
    // Class is non-static for supporting events
    public class PrinterManager
    {
        static PrinterManager()
        {
            Printers = new List<Printer>();
        }

        public static List<Printer> Printers { get; set; }

        public static void Add()
        {
            Console.WriteLine("Enter printer name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model");
            string model = Console.ReadLine();

                        
            if (!Printers.Where(p => p.Name == name).Any())
            {
                if (string.Compare(model, "Canon", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    var p1 = new CanonPrinter(name, model);
                    Printers.Add(p1);
                    Console.WriteLine("Printer added");
                }
                else if (string.Compare(model, "Epson", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    var p1 = new EpsonPrinter(name, model);
                    Printers.Add(p1);
                    Console.WriteLine("Printer added");
                }
                else
                {
                    Console.WriteLine("Unknown printer model");
                }                 
            }
        }

        // One method for printing
        public static void Print(Printer p1, ILogger logger)
        {
            if (Printers.Where(p => p.Model == p1.Model && p.Name == p1.Name).Any())
            {
                logger.Log("Print started");
                var o = new OpenFileDialog();
                o.ShowDialog();
                p1.Print(o.FileName);
                logger.Log("Print finished");
            }
            else
            {
                throw new ArgumentException("Printer not found");
            }
        }

        public void Register(Printer printer)
        {
            printer.Printing += StartPrinting;
        }

        public void Unregister(Printer printer)
        {
            printer.Printing -= StartPrinting;
        }

        public void StartPrinting(object sender, PrintEventArgs e)
        {
            Console.WriteLine($"Start printing, message: {e.PrintingArg}");
        }
    }
}
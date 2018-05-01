using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExam
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                CreatePrinter();
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(PrinterManager.Printers.Where(p=>p.Model=="Canon").First());
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(PrinterManager.Printers.Where(p => p.Model == "Epson").First());
            }

            while (true)
            {
                Print(PrinterManager.Printers.Where(p => p.Model == "Canon").First());
            }
        }

        private static void Print(Printer printer)
        {
            ILogger standartLogger = new DefaultLogger();
            PrinterManager.Print(printer, standartLogger);
            standartLogger.Log($"Printed on {printer.Model} {printer.Name}");
        }
        
        private static void CreatePrinter()
        {
            PrinterManager.Add();
        }
    }
}

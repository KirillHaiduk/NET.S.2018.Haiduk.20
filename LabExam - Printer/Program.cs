using System;

namespace LabExam
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {            
            Console.WriteLine("Select your choice:");
            Console.WriteLine("1:Add new printer");
            Console.WriteLine("2:Print on Canon");
            Console.WriteLine("3:Print on Epson");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {                
                Console.WriteLine("Enter printer model");
                string model = Console.ReadLine();
                Console.WriteLine("Enter printer name");
                string name = Console.ReadLine();
                CreatePrinter(name, model);
            }

            if (key.Key == ConsoleKey.D2)
            {
                Print(PrinterManager.Manager.GetPrinterByModel("Canon"));
            }

            if (key.Key == ConsoleKey.D3)
            {
                Print(PrinterManager.Manager.GetPrinterByModel("Epson"));
            }

            while (true)
            {
            }
        }

        private static void Print(Printer printer)
        {
            PrinterManager.Manager.Logger = new DefaultLogger("log.txt");
            PrinterManager.Manager.Print(printer);
            PrinterManager.Manager.Logger.Log($"Printed on {printer.Model} {printer.Name}");
        }

        private static void CreatePrinter(string name, string model) => PrinterManager.Manager.Add(PrinterFactory.CreateNewPrinter(name, model));
    }
}

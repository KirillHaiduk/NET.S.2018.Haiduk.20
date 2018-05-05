using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LabExam
{    
    /// <summary>
    /// Singleton class of Printer Manager
    /// </summary>
    public sealed class PrinterManager
    {
        private static readonly PrinterManager ManagerInstance = new PrinterManager();

        private readonly List<Printer> printerList = new List<Printer>();
                
        static PrinterManager()
        {
        }

        private PrinterManager()
        {
        }

        public static PrinterManager Manager
        {
            get => ManagerInstance;
        }      
        
        public ILogger Logger { get; set; }

        /// <summary>
        /// Method for adding new printer in printer list
        /// </summary>
        public void Add(Printer printer)
        {
            if (printer is null)
            {
                throw new InvalidOperationException("Printer instance was not created");
            }

            if (Manager.printerList.Where(p => p.Name == printer.Name && p.Model == printer.Model).Any())
            {
                throw new InvalidOperationException("Printer was already added to list");
            }
            else
            {
                printerList.Add(printer);
                printer.StartPrinting += (sender, args) => Logger.Log($"Printing started on printer {printer.Name} {printer.Model} on {args.TimeOfPrinting}");
                printer.EndPrinting += (sender, args) => Logger.Log($"Printing ended on printer {printer.Name} {printer.Model} on {args.TimeOfPrinting}");

                Logger.Log($"Printer {printer.Name} {printer.Model} added to list");
            }
        }

        /// <summary>
        /// Method for printing using given printer
        /// </summary>
        /// <param name="printer">Given printer to print on</param>
        /// <param name="logger">Instance of logger</param>
        public void Print(Printer printer)
        {
            if (Manager.printerList.Where(p => p.Model == printer.Model && p.Name == printer.Name).Any())
            {
                Logger.Log("Printing started");
                var o = new OpenFileDialog();
                o.ShowDialog();
                using (var stream = new FileStream(o.FileName, FileMode.Open))
                {
                    printer.Print(stream);
                }

                Logger.Log("Printing finished");
            }
            else
            {
                throw new ArgumentException("Printer not found");
            }
        }

        /// <summary>
        /// Method for showing all printers in list by given model
        /// </summary>
        /// <param name="model">Given model of printer</param>
        /// <returns>Sequence of printers of given model</returns>
        public Printer GetPrinterByModel(string model)
        {
            var printer = printerList.Where(p => p.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
            if (printer.Count() == 0)
            {
                throw new InvalidOperationException($"There is no {model} printers in manager list");
            }
            else
            {
                return printer.First();
            }
        }        
    }
}
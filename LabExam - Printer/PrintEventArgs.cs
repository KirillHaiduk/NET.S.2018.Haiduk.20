using System;

namespace LabExam
{
    /// <summary>
    /// Class for describing event of printing
    /// </summary>
    public sealed class PrintEventArgs : EventArgs
    {
        private string name;

        private string model;

        private string time;

        /// <summary>
        /// Constructor for printing event args
        /// </summary>
        /// <param name="printer">Printer that initiates event of printing</param>
        public PrintEventArgs(Printer printer)
        {
            this.name = printer.Name;
            this.model = printer.Model;
            this.time = DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// Property for getting name of printer which starts printing
        /// </summary>
        public string PrinterName => this.name;

        /// <summary>
        /// Property for getting model of printer which starts printing
        /// </summary>
        public string PrinterModel => this.model;

        /// <summary>
        /// Property for getting time of printing
        /// </summary>
        public string TimeOfPrinting => this.time;
    }
}

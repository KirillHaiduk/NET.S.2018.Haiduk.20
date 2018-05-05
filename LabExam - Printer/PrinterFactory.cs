using System;

namespace LabExam
{
    /// <summary>
    /// Static class for creating Printer instances as implementation of "Abstact Factory" pattern
    /// </summary>
    public static class PrinterFactory
    {
        /// <summary>
        /// Method for creating Printer instance depending on given model
        /// </summary>
        /// <param name="name">Printer name</param>
        /// <param name="model">Printer name</param>
        /// <returns>Epson printer if given model is "Epson", or Canon printer if given model is "Canon"</returns>
        public static Printer CreateNewPrinter(string name, string model)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException("Invalid parameters");
            }

            if (string.Compare(model, "Canon", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new CanonPrinter(name, model);
            }
            else if (string.Compare(model, "Epson", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new EpsonPrinter(name, model);
            }
            else
            {
                return null;
            }
        }
    }
}

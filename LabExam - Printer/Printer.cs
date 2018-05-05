using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    // Modified into abstract class for common method and properties
    public abstract class Printer : IEquatable<Printer>
    {
        protected string name;
        protected string model;

        /// <summary>
        /// Constructor for creating Printer instance
        /// </summary>
        /// <param name="name">Name of printer</param>
        /// <param name="model">Model of printer</param>
        public Printer(string name, string model)
        {
            this.name = name;
            this.model = model;           
        }        

        /// <summary>
        /// Description of printing events
        /// </summary>
        public event EventHandler<PrintEventArgs> StartPrinting = delegate { };

        public event EventHandler<PrintEventArgs> EndPrinting = delegate { };        

        /// <summary>
        /// Property for getting printer name
        /// </summary>
        public string Name => name;

        /// <summary>
        /// Property for getting printer model
        /// </summary>
        public string Model => model;

        /// <summary>
        /// Method for printing from given stream
        /// </summary>
        /// <param name="stream">Given stream</param>
        public void Print(Stream stream)
        {
            OnStartPrinting(new PrintEventArgs(this));
            SimulatePrinting(stream);
            OnEndPrinting(new PrintEventArgs(this));
        }

        /// <summary>
        /// Implementation of IEquatable interface to determine if two instances of printer are equal
        /// </summary>
        /// <param name="other">Given printer to compare with</param>
        /// <returns>True if two printers are equal; otherwise, false</returns>
        public bool Equals(Printer other)
        {
            if (other is null)
            {
                return this is null;
            }

            return this.Name == other.Name && this.Model == other.Model;
        }

        /// <summary>
        /// Overriding System.Object method GetHashCode
        /// </summary>
        /// <returns>YashCode of printer instance</returns>
        public override int GetHashCode()
        {
            var hashCode = -1585218528;            
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }

        protected abstract void SimulatePrinting(Stream stream);

        protected virtual void OnStartPrinting(PrintEventArgs e) => StartPrinting?.Invoke(this, e);

        protected virtual void OnEndPrinting(PrintEventArgs e) => EndPrinting?.Invoke(this, e);
    }
}
using System;
using XMLTechnologies;

namespace ConsoleUI
{
    /// <summary>
    /// Custom Logger for testing XmlConverter as implementation of ILogger interface
    /// </summary>
    public class CustomLogger : ILogger
    {
        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            Console.WriteLine(message + " URL doesn't match the pattern");
        }

        public void Fatal(string message)
        {
            throw new NotImplementedException();
        }

        public void Info(string message)
        {
            throw new NotImplementedException();
        }

        public void Log(string message)
        {            
        }
    }
}

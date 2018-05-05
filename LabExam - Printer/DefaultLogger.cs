using System;
using System.IO;

namespace LabExam
{
    /// <summary>
    /// Custom Logger
    /// </summary>
    public class DefaultLogger : ILogger
    {
        private readonly string destinationPath;

        /// <summary>
        /// Constructor for default logger instance
        /// </summary>
        /// <param name="path">Path of log file</param>
        public DefaultLogger(string path)
        {
            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentNullException("Wrong path");
            }

            this.destinationPath = path;
        }

        /// <summary>
        /// Writes message into log file
        /// </summary>
        /// <param name="destinationPath">Path of log file</param>
        /// <param name="message">Message to append in log file</param>
        public void Log(string message)
        {
            using (var stream = new FileStream(destinationPath, FileMode.OpenOrCreate))
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}

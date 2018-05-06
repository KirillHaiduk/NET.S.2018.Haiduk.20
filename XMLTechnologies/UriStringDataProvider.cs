using System;
using System.Collections.Generic;
using System.IO;
using XMLTechnologies.Interfaces;

namespace XMLTechnologies
{
    /// <summary>
    /// Implements IDataProvider interface for providing source of URLs from text file
    /// </summary>
    public class UriStringDataProvider : IDataProvider<string>
    {
        private string dataSource;

        /// <summary>
        /// Initializes a new instance of UriStringDataProvider with specified source path
        /// </summary>
        /// <param name="dataSourcePath">Path of source text file containing URLs</param>
        public UriStringDataProvider(string dataSourcePath)
        {
            if (string.IsNullOrEmpty(dataSourcePath))
            {
                throw new ArgumentNullException(nameof(dataSourcePath));
            }

            if (!File.Exists(dataSourcePath))
            {
                throw new FileNotFoundException(nameof(dataSourcePath));
            }

            this.dataSource = dataSourcePath;
        }

        public string GetSource => dataSource;

        /// <summary>
        /// Implementation of IDataProvider interface
        /// </summary>
        /// <returns>Collection of strings which are URLs</returns>
        public IEnumerable<string> GetData()
        {
            using (var fileStream = File.OpenRead(GetSource))
            using (var streamReader = new StreamReader(fileStream))
            {
                while (streamReader.Peek() > -1)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }
    }
}

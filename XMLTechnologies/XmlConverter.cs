using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XMLTechnologies
{
    /// <summary>
    /// Provides method for converting URLs stored in text file into XML representation using given pattern
    /// </summary>
    public class XmlConverter
    {
        /// <summary>
        /// Converts URLs into XML representation and writes them in XML file
        /// </summary>
        /// <param name="sourcePath">Path of source file which contains URLs</param>
        /// <param name="destinationPath">Path of destination XML file</param>
        /// <param name="logger">Instance of Logger to log operation</param>
        public void UrlToXmlConvert(string sourcePath, string destinationPath, ILogger logger)
        {
            InputValidation(sourcePath, destinationPath);

            using (var fileStream = File.OpenRead(sourcePath))
            using (var streamReader = new StreamReader(fileStream))            
            {
                var list = new List<XElement>();                
                while (streamReader.Peek() > -1)
                {                    
                    string url = streamReader.ReadLine();
                    if (!IsMatchUrlPattern(url))
                    {
                        logger.Error("Wrong string");
                        logger.Log($"String {url} is not match the URL pattern");
                        continue;
                    }
                    else
                    {
                        var root = new XElement("urladress", url.Substring(url.IndexOf(':') + 2), url.LastIndexOf('/'));
                        list.Add(root); 
                    }
                }

                var doc = new XDocument(list);                
                doc.Save(destinationPath);                
            }
        }

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentNullException("Wrong path");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File {nameof(sourcePath)} not found");
            }
        }

        private static bool IsMatchUrlPattern(string url)
        {
            Regex regex = new Regex(@"(http://|https://)", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(url))
            {
                return false;
            }

            return true;
        }
    }
}

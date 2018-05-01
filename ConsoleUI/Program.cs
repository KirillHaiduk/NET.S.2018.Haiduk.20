using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMLTechnologies;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var converter = new XmlConverter();
            var logger = new CustomLogger();
            string sourcePath = @"E:\URLs.txt";
            string destinationPath = @"E:\Converted.xml";
            converter.UrlToXmlConvert(sourcePath, destinationPath, logger);
        }
    }
}

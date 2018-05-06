using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using XMLTechnologies;
using XMLTechnologies.Interfaces;

namespace ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mockSource = Mock.Of<IDataProvider<string>>(d => d.GetSource == @"E:\URLs.txt");

            var mockStorage = Mock.Of<IStorage>(d => d.GetStoragePath() == @"E:\Converted.xml");
            
            var mockLogger = Mock.Of<ILogger>();            

            var converter = new XmlConverter(mockSource, new UrlPatternValidator<string, Uri>(mockLogger), mockStorage);
            
            converter.ToXmlConvert();
        }
    }
}

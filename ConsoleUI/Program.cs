using System;
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

            var dataProvider = new UriStringDataProvider(mockSource.GetSource);

            var converter = new XmlConverter(dataProvider, new UrlPatternValidator(mockLogger), mockStorage);

            var validator = new UrlPatternValidator(mockLogger);

            Console.WriteLine("Valid URLs from source:");
            foreach (var url in validator.ValidUrls(dataProvider.GetData()))
            {
                Console.WriteLine(url);
            }

            Console.WriteLine("\nURLs divided on hosts and segments:");
            foreach (var element in converter.XMLNodes())
            {
                Console.WriteLine(element.ToString());
            }

            Console.WriteLine("\nWriting URLs into XML document:");
            converter.ToXmlProcess();
            Console.WriteLine($"New XML document was created, see {mockStorage.GetStoragePath()}");
            Console.ReadLine();
        }
    }
}

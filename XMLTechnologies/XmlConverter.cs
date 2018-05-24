using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XMLTechnologies.Interfaces;

namespace XMLTechnologies
{
    /// <summary>
    /// Provides method for converting URLs stored in text file into XML representation using given pattern
    /// </summary>
    public class XmlConverter : IConverter
    {
        private IDataProvider<string> provider;

        private IValidator<string, string> validator;

        private IStorage storage;

        /// <summary>
        /// Creates new instance of XmlConverter
        /// </summary>
        /// <param name="provider">Instance which implements IDataProvider interface</param>
        /// <param name="validator">Instance which implements IValidator interface</param>
        /// <param name="storage">Instance which implements IStorage interface</param>
        public XmlConverter(IDataProvider<string> provider, IValidator<string, string> validator, IStorage storage)
        {
            if (provider is null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (validator is null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            if (storage is null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            this.provider = provider;
            this.validator = validator;
            this.storage = storage;
        }

        /// <summary>
        /// Converts URLs into XML representation and writes them in XML file
        /// </summary>
        public void ToXmlProcess()
        {
            var document = new XDocument();
            var root = new XElement("urlAddresses");
            root.Add(this.XMLNodes());
            document.Add(root);
            document.Save(storage.GetStoragePath());
        }

        /// <summary>
        /// Converts given URLs into XML representation
        /// </summary>
        /// <returns>Sequence of XML nodes</returns>
        public IEnumerable<XElement> XMLNodes()
        {
            foreach (var urlStr in validator.ValidUrls(provider.GetData()))
            {
                string fullUrl = urlStr.Substring(urlStr.IndexOf(':') + 3);
                string hostStr = fullUrl.Substring(0, fullUrl.IndexOf('/'));
                string[] segments = fullUrl.Substring(hostStr.Length).Split('/', '?');
                XElement host = new XElement("host");
                host.Add(new XAttribute("name", hostStr));

                XElement uri = new XElement("uri");
                XElement url = new XElement("urlAddress");
                foreach (var s in this.Segments(segments))
                {
                    uri.Add(new XElement("segment", s));
                }

                url.Add(host);
                url.Add(uri);
                yield return url;
            }
        }

        private IEnumerable<string> Segments(string[] input)
        {
            foreach (var segment in input)
            {
                if (string.IsNullOrWhiteSpace(segment))
                {
                    continue;
                }
                else
                {
                    yield return segment;
                }
            }
        }
    }
}

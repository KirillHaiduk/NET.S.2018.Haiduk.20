using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
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

        private IValidator<string, Uri> validator;

        private IStorage storage;

        /// <summary>
        /// Creates new instance of XmlConverter
        /// </summary>
        /// <param name="provider">Instance which implements IDataProvider interface</param>
        /// <param name="validator">Instance which implements IValidator interface</param>
        /// <param name="storage">Instance which implements IStorage interface</param>
        public XmlConverter(IDataProvider<string> provider, IValidator<string, Uri> validator, IStorage storage)
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
        public void ToXmlConvert()
        {
            var list = new List<XElement>();
            foreach (var url in validator.ValidUrls(provider.GetData()))
            {
                var root = new XElement("urladress", url.AbsolutePath);
                list.Add(root);
            }
            
            var doc = new XDocument(list);
            doc.Save(storage.GetStoragePath());
        }       
    }
}

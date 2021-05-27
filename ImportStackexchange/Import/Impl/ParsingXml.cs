using System;
using System.Collections.Generic;
using System.Xml;

namespace ImportStackexchange.Import.Impl
{
    /// <summary>
    /// Parsing only one file
    /// </summary>
    public class ParsingXml
    {
        private string _xmlFileName;
        public ParsingXml(string xmlFileName)
        {
            _xmlFileName = xmlFileName;
        }

        /// <summary>
        /// Read data from xml file
        /// </summary>
        public async IAsyncEnumerable<XmlReader> ParseAsync()
        {
            var reader = XmlReader.Create(_xmlFileName, new XmlReaderSettings
            {
                Async = true,
                IgnoreWhitespace = true
            }
            );

            while (await reader.ReadAsync())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name.Equals("row", StringComparison.InvariantCultureIgnoreCase))
                        {
                            yield return reader;
                        }
                        break;
                }
            }
        }
    }
}

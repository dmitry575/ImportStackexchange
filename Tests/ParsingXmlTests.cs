using ReaderStackExchangeXml.Models;
using ImportStackexchange.Import;
using ImportStackexchange.Import.Impl;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using Tests.Extentions;

namespace Tests
{
    public class ParsingXmlTests
    {
        private readonly List<string> _attributes = new List<string>()
        {
            "Id","TagName", "Count"
        };

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public async Task ReadXml()
        {
            var parsing = new ParsingXml("Data/Tags.xml");
            var count = 0;

            await foreach (var reader in parsing.ParseAsync())
            {
                ReadXml(reader);
                count++;
            }

            Assert.AreEqual(count, 5488);
        }

        [Test]
        public async Task SerializeXml()
        {
            var parsing = new ParsingXml("Data/Tags.xml");
            await foreach (var reader in parsing.ParseAsync())
            {
                Serialize(reader);
            }
        }


        private void ReadXml(XmlReader reader)
        {
            foreach (var atrName in _attributes)
            {
                var atribute = reader.GetAttribute(atrName);
                Assert.IsNotNull(atribute);
            }
        }

        private void Serialize(XmlReader reader)
        {
            var tag = reader.XmlDeserialize<Tag>();
            Assert.IsNotNull(tag);
        }
    }
}
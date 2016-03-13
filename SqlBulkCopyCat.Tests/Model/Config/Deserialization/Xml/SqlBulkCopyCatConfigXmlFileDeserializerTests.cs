using FluentAssertions;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Xml;
using SqlBulkCopyCat.Tests.Model.Config.Deserialization.Abstract;
using System.IO;
using System.Linq;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Xml
{
    public class SqlBulkCopyCatConfigXmlFileDeserializerTests : AbstractSqlBulkCopyCatConfigDeserializerTests
    {
        protected override string TestFilesDirectory
        {
            get
            {
                return @"./Model/Config/Deserialization/Xml/TestFiles";
            }
        }        

        [Fact]
        public void Deserialize_Success_Simple()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Simple.xml"));

            SimpleConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_EmptyColumnMappings()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("EmptyColumnMappings.xml"));

            EmptyColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_NoColumnMappings()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("NoColumnMappings.xml"));

            NoColumnMappingsConfigAssertions(config);
        }
    }
}

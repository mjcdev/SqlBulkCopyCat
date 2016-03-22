using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Xml;
using SqlBulkCopyCat.Tests.Model.Config.Deserialization.Abstract;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Xml
{
    public class CopyCatConfigXmlFileDeserializerTests : AbstractCopyCatConfigDeserializerTests
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
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Simple.xml"));

            SimpleConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_EmptyColumnMappings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("EmptyColumnMappings.xml"));

            EmptyColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_NoColumnMappings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("NoColumnMappings.xml"));

            NoColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_SqlBulkCopySettings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("SqlBulkCopySettings.xml"));

            SqlBulkCopySettingsAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_Ordinal()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Ordinal.xml"));

            OrdinalConfigAssertions(config);
        }
    }
}

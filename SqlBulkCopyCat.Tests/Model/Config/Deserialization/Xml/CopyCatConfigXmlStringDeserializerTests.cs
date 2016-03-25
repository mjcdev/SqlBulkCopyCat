using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Xml;
using SqlBulkCopyCat.Tests.Model.Config.Deserialization.Abstract;
using SqlBulkCopyCat.Tests.Model.Config.Deserialization.Xml;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Xml
{
    public class CopyCatConfigXmlStringDeserializerTests : AbstractCopyCatConfigDeserializerTests
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
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlStringDeserializer();

            var config = deserializer.Deserialize(ReadStringFromTestFile(XmlTestFiles.Simple));

            SimpleConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_EmptyColumnMappings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlStringDeserializer();

            var config = deserializer.Deserialize(ReadStringFromTestFile(XmlTestFiles.EmptyColumnMappings));

            EmptyColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_NoColumnMappings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlStringDeserializer();

            var config = deserializer.Deserialize(ReadStringFromTestFile(XmlTestFiles.NoColumnMappings));

            NoColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_SqlBulkCopySettings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlStringDeserializer();

            var config = deserializer.Deserialize(ReadStringFromTestFile(XmlTestFiles.SqlBulkCopySettings));

            SqlBulkCopySettingsAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_Ordinal()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigXmlStringDeserializer();

            var config = deserializer.Deserialize(ReadStringFromTestFile(XmlTestFiles.Ordinal));

            OrdinalConfigAssertions(config);
        }
    }
}

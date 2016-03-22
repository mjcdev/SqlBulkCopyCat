using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Json;
using SqlBulkCopyCat.Tests.Model.Config.Deserialization.Abstract;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Json
{
    public class CopyCatConfigJsonFileDeserializerTests : AbstractCopyCatConfigDeserializerTests
    {
        protected override string TestFilesDirectory
        {
            get
            {
                return @"./Model/Config/Deserialization/Json/TestFiles";
            }
        }

        [Fact]
        public void Deserialize_Success_Simple()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Simple.json"));

            SimpleConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_EmptyColumnMappings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("EmptyColumnMappings.json"));

            EmptyColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_NoColumnMappings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("NoColumnMappings.json"));

            NoColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_SqlBulkCopySettings()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("SqlBulkCopySettings.json"));

            SqlBulkCopySettingsAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_Ordinal()
        {
            ICopyCatConfigDeserializer deserializer = new CopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Ordinal.json"));

            OrdinalConfigAssertions(config);
        }
    }
}

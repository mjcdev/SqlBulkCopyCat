using FluentAssertions;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Json;
using SqlBulkCopyCat.Tests.Model.Config.Deserialization.Abstract;
using System.IO;
using System.Linq;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Json
{
    public class SqlBulkCopyCatConfigJsonFileDeserializerTests : AbstractSqlBulkCopyCatConfigDeserializerTests
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
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Simple.json"));

            SimpleConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_EmptyColumnMappings()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("EmptyColumnMappings.json"));

            EmptyColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_NoColumnMappings()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("NoColumnMappings.json"));

            NoColumnMappingsConfigAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_SqlBulkCopySettings()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("SqlBulkCopySettings.json"));

            SqlBulkCopySettingsAssertions(config);
        }

        [Fact]
        public void Deserialize_Success_Ordinal()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Ordinal.json"));

            OrdinalConfigAssertions(config);
        }
    }
}

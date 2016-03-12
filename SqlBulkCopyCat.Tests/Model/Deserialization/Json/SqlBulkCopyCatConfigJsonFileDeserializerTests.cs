using FluentAssertions;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Json;
using System.IO;
using System.Linq;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Json
{
    public class SqlBulkCopyCatConfigJsonFileDeserializerTests
    {
        private const string TestFilesDirectory = @"./Model/Deserialization/Json/TestFiles";

        private string TestFileLocation(string testFileName)
        {
            return Path.Combine(TestFilesDirectory, testFileName);
        }

        [Fact]
        public void Deserialize_Success_Simple()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigJsonFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Simple.json"));

            config.SourceConnectionString = "SourceConnectionString";
            config.DestinationConnectionString = "DestinationConnectionString";
            config.TableMappings.Should().HaveCount(1);

            var tableMapping = config.TableMappings.First();
            tableMapping.Destination.Should().Be("DestinationTable");
            tableMapping.Source.Should().Be("SourceTable");
            tableMapping.ColumnMappings.Should().HaveCount(1);

            var columnMapping = tableMapping.ColumnMappings.First();
            columnMapping.Destination.Should().Be("DestinationColumn");
            columnMapping.Source.Should().Be("SourceColumn");
        }
    }
}

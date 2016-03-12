using FluentAssertions;
using SqlBulkCopyCat.Model.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Deserialization.Xml;
using System.IO;
using System.Linq;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Deserialization.Xml
{
    public class SqlBulkCopyCatConfigXmlFileDeserializerTests
    {
        private const string TestFilesDirectory = @"./Model/Deserialization/Xml/TestFiles";

        private string TestFileLocation(string testFileName)
        {
            return Path.Combine(TestFilesDirectory, testFileName);
        }

        [Fact]
        public void Deserialize_Success_Simple()
        {
            ISqlBulkCopyCatConfigDeserializer deserializer = new SqlBulkCopyCatConfigXmlFileDeserializer();

            var config = deserializer.Deserialize(TestFileLocation("Simple.xml"));

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

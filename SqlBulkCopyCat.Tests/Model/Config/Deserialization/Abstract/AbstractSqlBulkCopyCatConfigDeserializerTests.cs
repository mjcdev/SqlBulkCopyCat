using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.IO;
using System.Linq;

namespace SqlBulkCopyCat.Tests.Model.Config.Deserialization.Abstract
{
    public abstract class AbstractSqlBulkCopyCatConfigDeserializerTests
    {
        protected abstract string TestFilesDirectory
        {
            get;
        }

        protected string TestFileLocation(string testFileName)
        {
            return Path.Combine(TestFilesDirectory, testFileName);
        }

        protected void SimpleConfigAssertions(SqlBulkCopyCatConfig config)
        {
            config.SourceConnectionString.Should().Be("SourceConnectionString");
            config.DestinationConnectionString.Should().Be("DestinationConnectionString");
            config.TableMappings.Should().HaveCount(1);

            var tableMapping = config.TableMappings.First();
            tableMapping.Destination.Should().Be("DestinationTable");
            tableMapping.Source.Should().Be("SourceTable");
            tableMapping.ColumnMappings.Should().HaveCount(1);

            var columnMapping = tableMapping.ColumnMappings.First();
            columnMapping.Destination.Should().Be("DestinationColumn");
            columnMapping.Source.Should().Be("SourceColumn");
        }

        protected void EmptyColumnMappingsConfigAssertions(SqlBulkCopyCatConfig config)
        {
            config.SourceConnectionString.Should().Be("SourceConnectionString");
            config.DestinationConnectionString.Should().Be("DestinationConnectionString");
            config.TableMappings.Should().HaveCount(1);

            var tableMapping = config.TableMappings.First();
            tableMapping.Destination.Should().Be("DestinationTable");
            tableMapping.Source.Should().Be("SourceTable");
            tableMapping.ColumnMappings.Should().HaveCount(0);
        }

        protected void NoColumnMappingsConfigAssertions(SqlBulkCopyCatConfig config)
        {
            config.SourceConnectionString.Should().Be("SourceConnectionString");
            config.DestinationConnectionString.Should().Be("DestinationConnectionString");
            config.TableMappings.Should().HaveCount(1);

            var tableMapping = config.TableMappings.First();
            tableMapping.Destination.Should().Be("DestinationTable");
            tableMapping.Source.Should().Be("SourceTable");
            tableMapping.ColumnMappings.Should().HaveCount(0);
        }
    }
}

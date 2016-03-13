using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Config
{
    public class ColumnMappingLogicTests
    {
        [Fact]
        public void SqlBulkCopyColumnMapping_NullSource()
        {
            var columnMapping = new ColumnMapping { Destination = "Destination", Source = null };

            columnMapping.BuildSqlBulkCopyColumnMapping().DestinationColumn.Should().Be("Destination");
        }

        [Fact]
        public void SqlBulkCopyColumnMapping_NullDestination()
        {
            var columnMapping = new ColumnMapping { Destination = null, Source = "Source" };

            columnMapping.BuildSqlBulkCopyColumnMapping().SourceColumn.Should().Be("Source");
        }

        [Fact]
        public void SqlBulkCopyColumnMapping_Get()
        {
            var columnMapping = new ColumnMapping { Destination = "Destination", Source = "Source" };

            var instance = columnMapping.BuildSqlBulkCopyColumnMapping();

            instance.DestinationColumn.Should().Be("Destination");
            instance.SourceColumn.Should().Be("Source");
        }
    }
}

using FluentAssertions;
using SqlBulkCopyCat.Builder;
using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace SqlBulkCopyCat.Tests.Builder
{
    public class SqlBulkCopyBuilderLogicTests
    {
        [Fact]
        public void Build_TableMappings()
        {
            using (var sqlConnection = new SqlConnection(@"Server=(local)\SQLExpress;Trusted_Connection=True;"))
            {
                var tableMapping = new TableMapping
                {
                    Destination = "Destination"
                };

                var bcp = SqlBulkCopyBuilder.Build(sqlConnection, tableMapping);

                bcp.DestinationTableName.Should().Be("Destination");             
            }
        }

        [Fact]
        public void Build_ColumnMappings_One()
        {
            using (var sqlConnection = new SqlConnection(@"Server=(local)\SQLExpress;Trusted_Connection=True;"))
            {
                var tableMapping = new TableMapping
                {
                    Destination = "Destination",
                    ColumnMappings = new List<ColumnMapping>
                    {
                        new ColumnMapping { Source = "Source", Destination = "Destination" }
                    }
                };

                var bcp = SqlBulkCopyBuilder.Build(sqlConnection, tableMapping);

                bcp.ColumnMappings.Should().HaveCount(1);
                bcp.ColumnMappings[0].SourceColumn.Should().Be("Source");
                bcp.ColumnMappings[0].DestinationColumn.Should().Be("Destination");
            }
        }

        [Fact]
        public void Build_ColumnMappings_Three()
        {
            using (var sqlConnection = new SqlConnection(@"Server=(local)\SQLExpress;Trusted_Connection=True;"))
            {                
                var tableMapping = new TableMapping
                {
                    Destination = "Destination",
                    ColumnMappings = new List<ColumnMapping>
                    {
                        new ColumnMapping { Source = "Source1", Destination = "Destination1" },
                        new ColumnMapping { Source = "Source2", Destination = "Destination2" },
                        new ColumnMapping { Source = "Source3", Destination = "Destination3" }
                    }
                };

                var bcp = SqlBulkCopyBuilder.Build(sqlConnection, tableMapping);

                bcp.ColumnMappings.Should().HaveCount(3);
            }
        }

        [Fact]
        public void Build_SqlBulkCopySettings_Null()
        {
            using (var sqlConnection = new SqlConnection(@"Server=(local)\SQLExpress;Trusted_Connection=True;"))
            {
                SqlBulkCopySettings sqlBulkCopySettings = null;

                var tableMapping = new TableMapping
                {
                    Destination = "Destination"
                };

                var bcp = SqlBulkCopyBuilder.Build(sqlConnection, tableMapping, sqlBulkCopySettings);

                bcp.BatchSize.Should().Be(500);
                bcp.BulkCopyTimeout.Should().Be(30);
                bcp.EnableStreaming.Should().Be(true);
            }
        }

        [Fact]
        public void Build_SqlBulkCopySettings()
        {
            using (var sqlConnection = new SqlConnection(@"Server=(local)\SQLExpress;Trusted_Connection=True;"))
            {
                SqlBulkCopySettings sqlBulkCopySettings = new SqlBulkCopySettings
                {
                    BatchSize = 600,
                    BulkCopyTimeout = 0,
                    EnableStreaming = false,
                    SqlBulkCopyOptions = (int)(SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.TableLock)
                };

                var tableMapping = new TableMapping
                {
                    Destination = "Destination"
                };

                var bcp = SqlBulkCopyBuilder.Build(sqlConnection, tableMapping, sqlBulkCopySettings);

                bcp.BatchSize.Should().Be(600);
                bcp.BulkCopyTimeout.Should().Be(0);
                bcp.EnableStreaming.Should().Be(false);
            }
        }
    }
}

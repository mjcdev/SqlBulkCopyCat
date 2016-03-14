using FluentAssertions;
using SqlBulkCopyCat.Extensions;
using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace SqlBulkCopyCat.Tests.Extensions
{
    public class SqlBulkCopyExtensionsLogicTests
    {
        private const string TestConnectionString = @"Server=(local)\SQLExpress;Trusted_Connection=True;";

        [Fact]
        public void ConfigureDestinationTableName()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var tableMapping = new TableMapping
                {
                    Destination = "Destination"
                };

                sqlBulkCopy.ConfigureDestinationTableName(tableMapping);

                sqlBulkCopy.DestinationTableName.Should().Be("Destination");
            }
        }

        [Fact]
        public void ConfigureColumnMappings_Empty()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var tableMapping = new TableMapping
                {
                    ColumnMappings = new List<ColumnMapping>()
                };

                sqlBulkCopy.ConfigureColumnMappings(tableMapping);

                sqlBulkCopy.ColumnMappings.Count.Should().Be(0);
            }
        }

        [Fact]
        public void ConfigureColumnMappings_One()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var tableMapping = new TableMapping
                {
                    ColumnMappings = new List<ColumnMapping>
                    {
                        new ColumnMapping { Source = "Source", Destination = "Destination" }
                    }
                };

                sqlBulkCopy.ConfigureColumnMappings(tableMapping);

                sqlBulkCopy.ColumnMappings.Count.Should().Be(1);
            }
        }

        [Fact]
        public void ConfireColumnMappings_Three()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var tableMapping = new TableMapping
                {
                    ColumnMappings = new List<ColumnMapping>
                    {
                        new ColumnMapping { Source = "Source1", Destination = "Destination1" },
                        new ColumnMapping { Source = "Source2", Destination = "Destination2" },
                        new ColumnMapping { Source = "Source3", Destination = "Destination3" }                        
                    }
                };

                sqlBulkCopy.ConfigureColumnMappings(tableMapping);

                sqlBulkCopy.ColumnMappings.Count.Should().Be(3);
            }
        }

        [Fact]
        public void ConfigureBatchSize_NullSettings()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                sqlBulkCopy.ConfigureBatchSize(null);

                sqlBulkCopy.BatchSize.Should().Be(500);
            }
        }

        [Fact]
        public void ConfigureBatchSize_NullBatchSize()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var sqlBulkCopyCatSettings = new SqlBulkCopySettings
                {
                    BatchSize = null
                };

                sqlBulkCopy.ConfigureBatchSize(sqlBulkCopyCatSettings);

                sqlBulkCopy.BatchSize.Should().Be(500);
            }
        }

        [Fact]
        public void ConfigureBatchSize_NotNullBatchSize()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var sqlBulkCopyCatSettings = new SqlBulkCopySettings
                {
                    BatchSize = 100
                };

                sqlBulkCopy.ConfigureBatchSize(sqlBulkCopyCatSettings);

                sqlBulkCopy.BatchSize.Should().Be(100);
            }
        }

        [Fact]
        public void ConfigureTimeout_NullSettings()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                sqlBulkCopy.ConfigureBulkCopyTimeout(null);

                sqlBulkCopy.BulkCopyTimeout.Should().Be(30);
            }
        }

        [Fact]
        public void ConfigureTimeout_NullTimeout()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var sqlBulkCopyCatSettings = new SqlBulkCopySettings
                {
                    BulkCopyTimeout = null
                };

                sqlBulkCopy.ConfigureBulkCopyTimeout(sqlBulkCopyCatSettings);

                sqlBulkCopy.BulkCopyTimeout.Should().Be(30);
            }
        }

        [Fact]
        public void ConfigureTimeout_NotNullTimeout()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var sqlBulkCopyCatSettings = new SqlBulkCopySettings
                {
                    BulkCopyTimeout = 600
                };

                sqlBulkCopy.ConfigureBulkCopyTimeout(sqlBulkCopyCatSettings);

                sqlBulkCopy.BulkCopyTimeout.Should().Be(600);
            }
        }

        [Fact]
        public void ConfigureEnableStreaming_NullSettings()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                sqlBulkCopy.ConfigureEnableStreaming(null);

                sqlBulkCopy.EnableStreaming.Should().Be(true);
            }
        }

        [Fact]
        public void ConfigureEnableStreaming_NullEnableStreaming()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var sqlBulkCopyCatSettings = new SqlBulkCopySettings
                {
                    EnableStreaming = null
                };

                sqlBulkCopy.ConfigureEnableStreaming(sqlBulkCopyCatSettings);

                sqlBulkCopy.EnableStreaming.Should().Be(true);
            }
        }

        [Fact]
        public void ConfigureEnableStreaming_NotNullEnableStreaming()
        {
            using (var sqlBulkCopy = new SqlBulkCopy(TestConnectionString))
            {
                var sqlBulkCopyCatSettings = new SqlBulkCopySettings
                {
                    EnableStreaming = false
                };

                sqlBulkCopy.ConfigureEnableStreaming(sqlBulkCopyCatSettings);

                sqlBulkCopy.EnableStreaming.Should().Be(false);
            }
        }
    }
}

using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Config
{
    public class CopyCatLogicTests
    {
        private string DummyConnectionString = @"Server = (local)\SQLExpress;Trusted_Connection=True;Initial Catalog=DummyDatabase";
        
        [Fact]
        public void NullCoalesceTableMappings_Null()
        {
            var config = new CopyCatConfig { TableMappings = null };

            config.TableMappings.Should().HaveCount(0);
            config.TableMappings.Should().NotBeNull();
        }

        [Fact]
        public void NullCoalesceColumnMappings_NotNull()
        {
            var config = new CopyCatConfig
            {
                TableMappings = new List<TableMapping>
                {
                    new TableMapping()
                }
            };

            config.TableMappings.Should().HaveCount(1);
            config.TableMappings.Should().NotBeNull();
        }

        [Fact]
        public void SourceInitialCatalogNull_ConnectionString()
        {
            var config = new CopyCatConfig
            {
                SourceConnectionString = DummyConnectionString,
                SourceInitialCatalog = null
            };

            new SqlConnectionStringBuilder(config.SourceConnectionString).InitialCatalog.Should().Be("DummyDatabase");
        }

        [Fact]
        public void SourceInitialCatalogNotNull_ConnectionString()
        {
            var config = new CopyCatConfig
            {
                SourceConnectionString = DummyConnectionString,
                SourceInitialCatalog = "SourceInitialCatalogOverride"
            };

            new SqlConnectionStringBuilder(config.SourceConnectionString).InitialCatalog.Should().Be("SourceInitialCatalogOverride");
        }

        [Fact]
        public void DestinationInitialCatalogNull_ConnectionString()
        {
            var config = new CopyCatConfig
            {
                DestinationConnectionString = DummyConnectionString,
                DestinationInitialCatalog = null
            };

            new SqlConnectionStringBuilder(config.DestinationConnectionString).InitialCatalog.Should().Be("DummyDatabase");
        }

        [Fact]
        public void DestinationInitialCatalogNotNull_ConnectionString()
        {
            var config = new CopyCatConfig
            {
                DestinationConnectionString = DummyConnectionString,
                DestinationInitialCatalog = "DestinationInitialCatalogOverride"
            };

            new SqlConnectionStringBuilder(config.DestinationConnectionString).InitialCatalog.Should().Be("DestinationInitialCatalogOverride");
        }
    }
}

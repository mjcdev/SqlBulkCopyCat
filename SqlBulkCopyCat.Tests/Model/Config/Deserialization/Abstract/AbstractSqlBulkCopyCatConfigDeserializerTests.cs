using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;
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
            config.SourceConnectionString.Should().Be(@"Data Source=(local)\SQLExpress;Initial Catalog=SourceOverride;Integrated Security=True");
            config._sourceConnectionString.Should().Be(@"Server = (local)\SQLExpress;Trusted_Connection=True;Initial Catalog=Source;");
            config.DestinationConnectionString.Should().Be(@"Data Source=(local)\SQLExpress;Initial Catalog=DestinationOverride;Integrated Security=True");
            config._destinationConnectionString.Should().Be(@"Server = (local)\SQLExpress;Trusted_Connection=True;Initial Catalog=Destination;");
            config.SourceInitialCatalog.Should().Be("SourceOverride");
            config.DestinationInitialCatalog.Should().Be("DestinationOverride");
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

        protected void SqlBulkCopySettingsAssertions(SqlBulkCopyCatConfig config)
        {
            config.SqlTransaction.Should().BeFalse();
            config.SqlBulkCopySettings.Should().NotBeNull();
            config.SqlBulkCopySettings.BatchSize.Should().Be(300);
            config.SqlBulkCopySettings.BulkCopyTimeout.Should().Be(1000);
            config.SqlBulkCopySettings.EnableStreaming.Should().BeFalse();
            config.SqlBulkCopySettings.SqlBulkCopyOptions.Should().HaveValue();
            config.SqlBulkCopySettings.SqlBulkCopyOptions.Should().Be(20);
            config.SqlBulkCopySettings.GetSqlBulkCopyOptions().Should().Be(SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.TableLock);
            
        }
    }
}

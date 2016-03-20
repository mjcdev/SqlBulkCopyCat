using SqlBulkCopyCat.Model.Config;
using SqlBulkCopyCat.Model.Config.Builder;
using SqlBulkCopyCat.Tests.System.Fixtures;
using System.Data.SqlClient;
using System.IO;
using Xunit;

namespace SqlBulkCopyCat.Tests.System
{
    public abstract class AbstractSqlBulkCopyCatTests : IClassFixture<SqlBulkCopyCatTestsFixture>
    {
        protected readonly string SourceConnectionString = Properties.Settings.Default["SourceConnectionString"].ToString();
        protected readonly string DestinationConnectionString = Properties.Settings.Default["DestinationConnectionString"].ToString();

        protected enum ConnectionType
        {
            Source,
            Destination,
        }

        protected SqlBulkCopyCatConfig BuildConfigFor(string fileName, string sourceDatabase, string destinationDatabase)
        {
            var configFilePath = Path.Combine(DirectoryConstants.Configs, fileName);

            var config = new SqlBulkCopyCatConfigBuilder().FromXmlFile(configFilePath);

            config.SourceConnectionString = ConnectionStringBuilder(ConnectionType.Source, sourceDatabase);
            config.DestinationConnectionString = ConnectionStringBuilder(ConnectionType.Destination, destinationDatabase);

            return config;
        }

        protected string ConnectionStringBuilder(ConnectionType connectionType, string databaseName)
        {
            string baseConnectionString = string.Empty;

            if (connectionType == ConnectionType.Source)
            {
                baseConnectionString = SourceConnectionString;
            }
            if (connectionType == ConnectionType.Destination)
            {
                baseConnectionString = DestinationConnectionString;
            }

            var connectionString = new SqlConnectionStringBuilder(baseConnectionString);
            connectionString.InitialCatalog = databaseName;
            return connectionString.ToString();
        }       

        protected int RowCountFor(ConnectionType connectionType, string databaseName, string tableName)
        {
            var connectionString = ConnectionStringBuilder(connectionType, databaseName);

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(string.Format("SELECT COUNT(*) FROM {0}", tableName), connection))
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
    }
}

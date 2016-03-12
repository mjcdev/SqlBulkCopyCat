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
        protected readonly string ConnectionString = Properties.Settings.Default["ConnectionString"].ToString();
     
        protected SqlBulkCopyCatConfig BuildConfigFor(string fileName, string sourceDatabase, string destinationDatabase)
        {
            var configFilePath = Path.Combine(DirectoryConstants.Configs, fileName);

            var config = new SqlBulkCopyCatConfigBuilder().FromXmlFile(configFilePath);

            config.SourceConnectionString = ConnectionStringBuilder(sourceDatabase);
            config.DestinationConnectionString = ConnectionStringBuilder(destinationDatabase);

            return config;
        }

        protected string ConnectionStringBuilder(string databaseName)
        {
            var connectionString = new SqlConnectionStringBuilder(ConnectionString);
            connectionString.InitialCatalog = databaseName;
            return connectionString.ToString();
        }       

        protected int RowCountFor(string databaseName, string tableName)
        {
            var connectionString = ConnectionStringBuilder(databaseName);

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

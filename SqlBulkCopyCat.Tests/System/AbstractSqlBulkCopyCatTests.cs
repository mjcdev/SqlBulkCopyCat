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
        private readonly string ConnectionString = Properties.Settings.Default["ConnectionString"].ToString();
        private const string ScriptsDirectory = @"./System/Scripts";
        private const string ConfigsDirectory = @"./System/Configs";

        protected SqlBulkCopyCatConfig BuildConfigFor(string fileName, string sourceDatabase, string destinationDatabase)
        {
            var configFilePath = Path.Combine(ConfigsDirectory, fileName);

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


        protected void ExecuteSqlFile(string fileName)
        {
            var filePath = Path.Combine(ScriptsDirectory, fileName);

            var fileContent = File.ReadAllText(filePath);

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(fileContent, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    public class SqlBulkCopyCatTestsFixture : IDisposable
    {
        private string ConnectionString = Properties.Settings.Default["ConnectionString"].ToString();
        private string SchemaDirectory = @"./System/Fixtures/Schema";
        
        public SqlBulkCopyCatTestsFixture()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var scriptsToExecute = new List<string>() { "DropDatabases.sql", "CreateDatabases.sql", "CreateTables.sql" };

                connection.Open();

                foreach(var script in scriptsToExecute)
                {
                    using (var command = new SqlCommand(ReadSqlFileContent(script), connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Dispose()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(ReadSqlFileContent("DropDatabases.sql"), connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private string ReadSqlFileContent(string fileName)
        {
            var filePath = Path.Combine(SchemaDirectory, fileName);

            return File.ReadAllText(filePath);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.IO;

namespace SqlBulkCopyCat.Tests.System
{
    public static class SqlFile
    {
        private static string[] GO = new string[] { "\r\nGO\r\n" };

        public static void ExecuteNonQuery(string filePath, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string[] commands = File.ReadAllText(filePath).Split(GO, StringSplitOptions.RemoveEmptyEntries);

                foreach (var command in commands)
                {
                    using (var sqlCommand = new SqlCommand(command, connection))
                    {
                        sqlCommand.CommandTimeout = 0;
                        sqlCommand.ExecuteNonQuery();
                    }
                }               
            }
        }
    }
}

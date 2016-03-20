using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    public class SqlBulkCopyCatTestsFixture : IDisposable
    {
        private string SourceConnectionString = Properties.Settings.Default["SourceConnectionString"].ToString();
        private string DestinationConnectionString = Properties.Settings.Default["DestinationConnectionString"].ToString();

        public SqlBulkCopyCatTestsFixture()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Schema, "CreateSourceDatabase.sql"), SourceConnectionString);
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Schema, "CreateDestinationDatabase.sql"), DestinationConnectionString);
        }

        public void Dispose()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Schema, "DropSourceDatabase.sql"), SourceConnectionString);
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Schema, "DropDestinationDatabase.sql"), DestinationConnectionString);
        }
    }
}
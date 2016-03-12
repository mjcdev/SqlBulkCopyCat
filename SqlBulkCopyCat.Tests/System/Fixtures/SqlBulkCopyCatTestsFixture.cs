using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    public class SqlBulkCopyCatTestsFixture : IDisposable
    {
        private string ConnectionString = Properties.Settings.Default["ConnectionString"].ToString();

        public SqlBulkCopyCatTestsFixture()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Schema, "CreateDatabases.sql"), ConnectionString);            
        }

        public void Dispose()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Schema, "DropDatabases.sql"), ConnectionString);
        }
    }
}
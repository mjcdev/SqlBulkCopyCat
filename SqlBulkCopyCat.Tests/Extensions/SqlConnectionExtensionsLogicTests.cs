using System.Data.SqlClient;
using Xunit;
using SqlBulkCopyCat.Extensions;
using FluentAssertions;
using SqlBulkCopyCat.Model.Config;

namespace SqlBulkCopyCat.Tests.Extensions
{
    public class SqlConnectionExtensionsLogicTests
    {
        private string TestConnectionString = Properties.Settings.Default["ConnectionString"].ToString();

        [Fact]
        public void BeginTransaction_NullSettings()
        {
            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.BeginTransaction(copyCatConfig : null).Should().BeNull();
            }
        }

        [Fact]
        public void BeginTransaction_NullSqlTransaction()
        {
            var copyCatConfig = new CopyCatConfig
            {
                SqlTransaction = null
            };

            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.BeginTransaction(copyCatConfig).Should().BeNull();
            }
        }

        [Fact]
        public void BeginTransaction_SqlTransaction_True()
        {
            var copyCatConfig = new CopyCatConfig
            {
                SqlTransaction = true
            };

            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.BeginTransaction(copyCatConfig).Should().NotBeNull();
            }
        }

        [Fact]
        public void BeginTransaction_SqlTransaction_False()
        {
            var copyCatConfig = new CopyCatConfig
            {
                SqlTransaction = false
            };

            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.BeginTransaction(copyCatConfig).Should().BeNull();
            }
        }
    }
}

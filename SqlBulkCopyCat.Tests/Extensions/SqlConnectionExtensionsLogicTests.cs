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
                sqlConnection.BeginTransaction(sqlBulkCopyCatConfig : null).Should().BeNull();
            }
        }

        [Fact]
        public void BeginTransaction_NullSqlTransaction()
        {
            var sqlBulkCopyCatConfig = new SqlBulkCopyCatConfig
            {
                SqlTransaction = null
            };

            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.BeginTransaction(sqlBulkCopyCatConfig).Should().BeNull();
            }
        }

        [Fact]
        public void BeginTransaction_SqlTransaction_True()
        {
            var sqlBulkCopyCatConfig = new SqlBulkCopyCatConfig
            {
                SqlTransaction = true
            };

            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.BeginTransaction(sqlBulkCopyCatConfig).Should().NotBeNull();
            }
        }

        [Fact]
        public void BeginTransaction_SqlTransaction_False()
        {
            var sqlBulkCopyCatConfig = new SqlBulkCopyCatConfig
            {
                SqlTransaction = false
            };

            using (var sqlConnection = new SqlConnection(TestConnectionString))
            {
                sqlConnection.BeginTransaction(sqlBulkCopyCatConfig).Should().BeNull();
            }
        }
    }
}

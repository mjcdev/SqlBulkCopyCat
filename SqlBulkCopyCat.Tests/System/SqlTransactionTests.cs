using FluentAssertions;
using System.Data.SqlClient;
using System.IO;
using Xunit;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    [Collection("Sql")]
    public class SqlTransactionTests : AbstractSqlBulkCopyCatTests
    {
        [Fact]
        public void Copy_SqlTransactionFail_True()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"SimpleOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("SqlTransactionTrue.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            Assert.Throws<SqlException>(() => sqlBulkCopyCat.Copy());

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(0);
        }

        [Fact]
        public void Copy_SqlTransactionFail_False()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts, "SimpleOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("SqlTransactionFalse.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            Assert.Throws<SqlException>(() => sqlBulkCopyCat.Copy());

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);
        }

        [Fact]
        public void Copy_SqlTransactionFail_Omitted()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts, "SimpleOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("SqlTransactionOmitted.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            Assert.Throws<SqlException>(() => sqlBulkCopyCat.Copy());

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);
        }
    }
}

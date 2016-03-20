using FluentAssertions;
using System.IO;
using Xunit;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    [Collection("Sql")]
    public class SqlBulkCopyCatComplexTests : AbstractSqlBulkCopyCatTests
    {
        [Fact]
        public void Copy_Complex_OneRecord()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"ComplexOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("ComplexOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.ComplexSourceOneTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.ComplexDestinationOneTable).Should().Be(1);

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.ComplexSourceTwoTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.ComplexDestinationTwoTable).Should().Be(1);

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.ComplexSourceThreeTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.ComplexDestinationThreeTable).Should().Be(1);
        }       
    }
}

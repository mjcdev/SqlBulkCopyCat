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
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"ComplexOneRecord.sql"), ConnectionString);

            var config = BuildConfigFor("ComplexOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();

            RowCountFor(DatabaseConstants.SourceDatabase, DatabaseConstants.ComplexSourceOneTable).Should().Be(1);
            RowCountFor(DatabaseConstants.DestinationDatabase, DatabaseConstants.ComplexDestinationOneTable).Should().Be(1);

            RowCountFor(DatabaseConstants.SourceDatabase, DatabaseConstants.ComplexSourceTwoTable).Should().Be(1);
            RowCountFor(DatabaseConstants.DestinationDatabase, DatabaseConstants.ComplexDestinationTwoTable).Should().Be(1);

            RowCountFor(DatabaseConstants.SourceDatabase, DatabaseConstants.ComplexSourceThreeTable).Should().Be(1);
            RowCountFor(DatabaseConstants.DestinationDatabase, DatabaseConstants.ComplexDestinationThreeTable).Should().Be(1);
        }       
    }
}

using FluentAssertions;
using System.IO;
using Xunit;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    [Collection("Sql")]
    public class SqlBulkCopyCatDataTypeTests : AbstractSqlBulkCopyCatTests
    {
        [Fact]
        public void Copy_DataTypes_OneRecord()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"DataTypesOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("DataTypesOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.DataTypesSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.DataTypesDestinationTable).Should().Be(1);
        }       
    }
}

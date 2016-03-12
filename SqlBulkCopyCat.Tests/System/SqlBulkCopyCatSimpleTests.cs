using FluentAssertions;
using System.IO;
using Xunit;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    public class SqlBulkCopyCatSimpleTests : AbstractSqlBulkCopyCatTests
    {
        [Fact]
        public void Copy_Simple_OneRecord()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"SimpleOneRecord.sql"), ConnectionString);

            var config = BuildConfigFor("SimpleOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();

            RowCountFor(DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);
        }
        
        [Fact]
        public void Copy_Simple_OneRecord_View()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts, "SimpleOneRecord.sql"), ConnectionString);

            var config = BuildConfigFor("SimpleOneRecordView.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();

            RowCountFor(DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceView).Should().Be(1);
            RowCountFor(DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);
        }
        
        [Fact]
        public void Copy_Simple_OneRecord_Schema()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts, "SimpleOneRecord.sql"), ConnectionString);

            var config = BuildConfigFor("SimpleOneRecordSchema.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();

            RowCountFor(DatabaseConstants.SourceDatabase, string.Format("{0}.{1}", DatabaseConstants.SourceSchema, DatabaseConstants.SimpleSourceTable)).Should().Be(1);
            RowCountFor(DatabaseConstants.DestinationDatabase, string.Format("{0}.{1}", DatabaseConstants.DestinationSchema, DatabaseConstants.SimpleDestinationTable)).Should().Be(1);
        }      
    }
}

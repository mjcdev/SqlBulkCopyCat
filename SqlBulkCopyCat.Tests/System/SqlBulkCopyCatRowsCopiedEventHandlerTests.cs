using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Xunit;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    [Collection("Sql")]
    public class SqlBulkCopyCatSqlRowsCopiedEventHandlerTests : AbstractSqlBulkCopyCatTests
    {
        private int DummyEventOneVariable;
        private int DummyEventTwoVariable;
        private int DummyEventThreeVariable;

        [Fact]
        public void Copy_SqlRowsCopiedEventHandler_NullEvents()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts, "SimpleOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("SimpleOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            config.SqlBulkCopySettings = new SqlBulkCopySettings { NotifyAfter = 1 };

            var sqlBulkCopyCat = new CopyCat(config, null);

            sqlBulkCopyCat.Copy();

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);
        }

        [Fact]
        public void Copy_SqlRowsCopiedEventHandler_OneEvent()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"SimpleOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("SimpleOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            config.SqlBulkCopySettings = new SqlBulkCopySettings { NotifyAfter = 1 };

            var events = new List<SqlRowsCopiedEventHandler>
            {
                DummyEventOne,
            };

            var sqlBulkCopyCat = new CopyCat(config, events);

            sqlBulkCopyCat.Copy();

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);

            DummyEventOneVariable.Should().Be(1);
        }        

        [Fact]
        public void Copy_SqlRowsCopiedEventHandler_TwoEvents()
        {
            SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts, "SimpleOneRecord.sql"), SourceConnectionString);

            var config = BuildConfigFor("SimpleOneRecord.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            config.SqlBulkCopySettings = new SqlBulkCopySettings { NotifyAfter = 1 };

            var events = new List<SqlRowsCopiedEventHandler>
            {                
                DummyEventTwo,
                DummyEventThree,
            };


            var sqlBulkCopyCat = new CopyCat(config, events);

            sqlBulkCopyCat.Copy();

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.SimpleSourceTable).Should().Be(1);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.SimpleDestinationTable).Should().Be(1);

            DummyEventTwoVariable.Should().Be(1);
            DummyEventThreeVariable.Should().Be(1);
        }

        private void DummyEventOne(object sender, SqlRowsCopiedEventArgs e)
        {
            DummyEventOneVariable++;
        }

        private void DummyEventTwo(object sender, SqlRowsCopiedEventArgs e)
        {
            DummyEventTwoVariable++;
        }

        private void DummyEventThree(object sender, SqlRowsCopiedEventArgs e)
        {
            DummyEventThreeVariable++;
        }
    }
}

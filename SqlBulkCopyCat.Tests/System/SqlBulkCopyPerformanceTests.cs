using FluentAssertions;
using System;
using System.Diagnostics;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    [Collection("Sql")]
    public class SqlBulkCopyCatPerformanceTests : AbstractSqlBulkCopyCatTests
    {
        private ITestOutputHelper _testOutputHelper;

        public SqlBulkCopyCatPerformanceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait("Category", "Performance")]
        public void Copy_Performance()
        {
            var dataSetup = MethodTimer(() => SqlFile.ExecuteNonQuery(Path.Combine(DirectoryConstants.Scripts,"Performance.sql"), SourceConnectionString));

            _testOutputHelper.WriteLine(string.Format("{0} seconds for Test Data Setup.", dataSetup.TotalSeconds.ToString()));

            var config = BuildConfigFor("Performance.xml", DatabaseConstants.SourceDatabase, DatabaseConstants.DestinationDatabase);

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            var copy = MethodTimer(() => sqlBulkCopyCat.Copy());

            _testOutputHelper.WriteLine(string.Format("{0} seconds for Copy.", copy.TotalSeconds.ToString()));

            RowCountFor(ConnectionType.Source, DatabaseConstants.SourceDatabase, DatabaseConstants.PerformanceSourceTable).Should().Be(1048576);
            RowCountFor(ConnectionType.Destination, DatabaseConstants.DestinationDatabase, DatabaseConstants.PerformanceDestinationTable).Should().Be(1048576);
        }

        private TimeSpan MethodTimer(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action.Invoke();

            stopwatch.Stop();

            return stopwatch.Elapsed;
        }
    }
}

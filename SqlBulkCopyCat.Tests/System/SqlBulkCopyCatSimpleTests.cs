using SqlBulkCopyCat.Model.Config;
using SqlBulkCopyCat.Model.Config.Builder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SqlBulkCopyCat.Tests.System.Fixtures
{
    public class SqlBulkCopyCatSimpleTests : AbstractSqlBulkCopyCatTests
    {
        [Fact]
        public void Copy_Simple_OneRecord()
        {
            ExecuteSqlFile("SimpleOneRecord.sql");

            var config = BuildConfigFor("SimpleOneRecord.xml", "BulkCopyCatTestsSource","BulkCopyCatTestsDestination");

            var sqlBulkCopyCat = new SqlBulkCopyCat(config);

            sqlBulkCopyCat.Copy();
        }       
        
    }
}

using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Config
{
    public class SqlBulkCopySettingsLogicTests
    {
        [Fact]
        public void SqlBulkCopyOptions_SetSqlBulkCopyOptions_Simple()
        {
            var sqlBulkCopySettings = new SqlBulkCopySettings();

            sqlBulkCopySettings.SetSqlBulkCopyOptions(SqlBulkCopyOptions.TableLock);

            sqlBulkCopySettings.SqlBulkCopyOptions.Should().Be((int)SqlBulkCopyOptions.TableLock);
        }

        [Fact]
        public void SqlBulkCopyOptions_SetSqlBulkCopyOptions_Flagged()
        {
            var sqlBulkCopySettings = new SqlBulkCopySettings();

            sqlBulkCopySettings.SetSqlBulkCopyOptions(SqlBulkCopyOptions.UseInternalTransaction | SqlBulkCopyOptions.KeepNulls);

            sqlBulkCopySettings.SqlBulkCopyOptions.Should().Be((int)(SqlBulkCopyOptions.UseInternalTransaction | SqlBulkCopyOptions.KeepNulls));
        }

        [Fact]
        public void SqlBulkCopyOptions_GetSqlBulkCopyOptions_Null()
        {
            var sqlBulkCopySettings = new SqlBulkCopySettings { SqlBulkCopyOptions = null };

            sqlBulkCopySettings.SqlBulkCopyOptions.Should().Be(null);
            sqlBulkCopySettings.GetSqlBulkCopyOptions().Should().Be(SqlBulkCopyOptions.Default);            
        }

        [Fact]
        public void SqlBulkCopyOptions_GetSqlBulkCopyOptions_Simple()
        {
            var sqlBulkCopySettings = new SqlBulkCopySettings { SqlBulkCopyOptions = 1};

            sqlBulkCopySettings.SqlBulkCopyOptions.Should().Be(1);
            sqlBulkCopySettings.GetSqlBulkCopyOptions().Should().Be(SqlBulkCopyOptions.KeepIdentity);            
        }

        [Fact]
        public void SqlBulkCopyOptions_GetSqlBulkCopyOptions_Flagged()
        {
            var sqlBulkCopySettings = new SqlBulkCopySettings { SqlBulkCopyOptions = 13 };

            sqlBulkCopySettings.SqlBulkCopyOptions.Should().Be(13);
            sqlBulkCopySettings.GetSqlBulkCopyOptions().Should().Be(SqlBulkCopyOptions.KeepNulls | SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.KeepIdentity);
        }
    }
}

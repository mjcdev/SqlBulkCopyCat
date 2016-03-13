using SqlBulkCopyCat.Extensions;
using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;

namespace SqlBulkCopyCat.Builder
{
    public static class SqlBulkCopyBuilder
    {
        public static SqlBulkCopy Build(SqlConnection sqlConnection, TableMapping tableMapping, SqlBulkCopySettings sqlBulkCopySettings = null, SqlTransaction sqlTransaction = null)
        {
            var sqlBulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction);

            sqlBulkCopy.ConfigureDestinationTableName(tableMapping);
            sqlBulkCopy.ConfigureColumnMappings(tableMapping);        

            return sqlBulkCopy;
        }
    }
}

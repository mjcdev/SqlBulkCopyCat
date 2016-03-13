using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;
using System.Linq;

namespace SqlBulkCopyCat.Builder
{
    public static class SqlBulkCopyBuilder
    {
        public static SqlBulkCopy Build(SqlConnection sqlConnection, TableMapping tableMapping, SqlBulkCopySettings sqlBulkCopySettings = null, SqlTransaction sqlTransaction = null)
        {
            var sqlBulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction);

            sqlBulkCopy.DestinationTableName = tableMapping.Destination;
            
            if (tableMapping.ColumnMappings.Any())
            {
                sqlBulkCopy.ColumnMappings.Clear();

                foreach(var columnMapping in tableMapping.ColumnMappings)
                {
                    sqlBulkCopy.ColumnMappings.Add(columnMapping.BuildSqlBulkCopyColumnMapping());
                }
            }          

            return sqlBulkCopy;
        }
    }
}

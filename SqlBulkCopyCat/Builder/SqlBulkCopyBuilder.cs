using SqlBulkCopyCat.Extensions;
using SqlBulkCopyCat.Model.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlBulkCopyCat.Builder
{
    public static class SqlBulkCopyBuilder
    {
        public static SqlBulkCopy Build(SqlConnection sqlConnection, TableMapping tableMapping, SqlBulkCopySettings sqlBulkCopySettings = null, SqlTransaction sqlTransaction = null, IEnumerable<SqlRowsCopiedEventHandler> sqlRowsCopiedEventHandlers = null)
        {
            var sqlBulkCopyOptions = SqlBulkCopyOptions.Default;

            if (sqlBulkCopySettings != null)
            {
                sqlBulkCopyOptions = sqlBulkCopySettings.GetSqlBulkCopyOptions();
            }

            var sqlBulkCopy = new SqlBulkCopy(sqlConnection, sqlBulkCopyOptions, sqlTransaction);

            sqlBulkCopy.ConfigureDestinationTableName(tableMapping);
            sqlBulkCopy.ConfigureColumnMappings(tableMapping);
            sqlBulkCopy.ConfigureBatchSize(sqlBulkCopySettings);
            sqlBulkCopy.ConfigureBulkCopyTimeout(sqlBulkCopySettings);
            sqlBulkCopy.ConfigureEnableStreaming(sqlBulkCopySettings);
            sqlBulkCopy.ConfigureNotifyAfter(sqlBulkCopySettings);

            if (sqlRowsCopiedEventHandlers != null)
            {
                sqlBulkCopy.ConfigureSqlRowsCopiedEventHandlers(sqlRowsCopiedEventHandlers);
            }

            return sqlBulkCopy;
        }
    }
}

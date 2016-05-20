﻿using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SqlBulkCopyCat.Extensions
{
    internal static class SqlBulkCopyExtensions
    {
        private const int BatchSizeDefault = 500;
        private const int BulkCopyTimeoutDefault = 30;
        private const bool EnableStreamingDefault = true;
        private const int NotifyAfterDefault = 0;

        internal static SqlBulkCopy ConfigureColumnMappings(this SqlBulkCopy sqlBulkCopy, TableMapping tableMapping)
        {
            if (tableMapping.ColumnMappings.Any())
            {
                sqlBulkCopy.ColumnMappings.Clear();

                foreach (var columnMapping in tableMapping.ColumnMappings)
                {
                    sqlBulkCopy.ColumnMappings.Add(columnMapping.BuildSqlBulkCopyColumnMapping());
                }
            }

            return sqlBulkCopy;
        }

        internal static SqlBulkCopy ConfigureDestinationTableName(this SqlBulkCopy sqlBulkCopy, TableMapping tableMapping)
        {
            sqlBulkCopy.DestinationTableName = tableMapping.Destination;

            return sqlBulkCopy;
        }

        internal static SqlBulkCopy ConfigureBatchSize(this SqlBulkCopy sqlBulkCopy, SqlBulkCopySettings sqlBulkCopySettings)
        {
            if (sqlBulkCopySettings != null && sqlBulkCopySettings.BatchSize.HasValue)
            {
                sqlBulkCopy.BatchSize = sqlBulkCopySettings.BatchSize.Value;                
            }
            else
            {
                sqlBulkCopy.BatchSize = BatchSizeDefault;
            }

            return sqlBulkCopy;            
        }

        internal static SqlBulkCopy ConfigureBulkCopyTimeout(this SqlBulkCopy sqlBulkCopy, SqlBulkCopySettings sqlBulkCopySettings)
        {
            if (sqlBulkCopySettings != null && sqlBulkCopySettings.BulkCopyTimeout.HasValue)
            {
                sqlBulkCopy.BulkCopyTimeout = sqlBulkCopySettings.BulkCopyTimeout.Value;
            }
            else
            {
                sqlBulkCopy.BulkCopyTimeout = BulkCopyTimeoutDefault;
            }

            return sqlBulkCopy;
        }

        internal static SqlBulkCopy ConfigureEnableStreaming(this SqlBulkCopy sqlBulkCopy, SqlBulkCopySettings sqlBulkCopySettings)
        {
            if (sqlBulkCopySettings != null && sqlBulkCopySettings.EnableStreaming.HasValue)
            {
                sqlBulkCopy.EnableStreaming = sqlBulkCopySettings.EnableStreaming.Value;
            }
            else
            {
                sqlBulkCopy.EnableStreaming = EnableStreamingDefault;
            }

            return sqlBulkCopy;
        }

        internal static SqlBulkCopy ConfigureNotifyAfter(this SqlBulkCopy sqlBulkCopy, SqlBulkCopySettings sqlBulkCopySettings)
        {
            if (sqlBulkCopySettings != null && sqlBulkCopySettings.NotifyAfter.HasValue)
            {
                sqlBulkCopy.NotifyAfter = sqlBulkCopySettings.NotifyAfter.Value;
            }
            else
            {
                sqlBulkCopy.NotifyAfter = NotifyAfterDefault;
            }

            return sqlBulkCopy;
        }

        internal static SqlBulkCopy ConfigureSqlRowsCopiedEventHandlers(this SqlBulkCopy sqlBulkCopy, IEnumerable<SqlRowsCopiedEventHandler> sqlRowsCopiedEventHandlers)
        {
            if (sqlRowsCopiedEventHandlers != null)
            {
                foreach(var eventHandler in sqlRowsCopiedEventHandlers)
                {
                    sqlBulkCopy.SqlRowsCopied += eventHandler;
                }
            }

            return sqlBulkCopy;
        }
    }
}

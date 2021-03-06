﻿using Dapper;
using SqlBulkCopyCat.Builder;
using SqlBulkCopyCat.Extensions;
using SqlBulkCopyCat.Model.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SqlBulkCopyCat
{
    public class CopyCat
    {
        private readonly CopyCatConfig _config;
        private readonly IEnumerable<SqlRowsCopiedEventHandler> _sqlRowsCopiedEventHandlers;

        public CopyCat(CopyCatConfig copyCatConfig, IEnumerable<SqlRowsCopiedEventHandler> sqlRowsCopiedEventHandlers = null)
        {
            _config = copyCatConfig;
            _sqlRowsCopiedEventHandlers = sqlRowsCopiedEventHandlers;        
        }

        public void Copy()
        {
            SqlTransaction sqlTransaction = null;

            using (var writeConnection = new SqlConnection(_config.DestinationConnectionString))
            {
                try
                {
                    writeConnection.Open();
                    sqlTransaction = writeConnection.BeginTransaction(_config);

                    foreach (var tableMapping in _config.TableMappings.OrderBy(tm => tm.Ordinal))
                    {
                        using (var readConnection = new SqlConnection(_config.SourceConnectionString))
                        using (var reader = readConnection.ExecuteReader(tableMapping.BuildSelectSql()))
                        using (var bcp = SqlBulkCopyBuilder.Build(writeConnection, tableMapping, _config.SqlBulkCopySettings, sqlTransaction, _sqlRowsCopiedEventHandlers))
                        {
                            bcp.WriteToServer(reader);
                        }
                    }

                    if (sqlTransaction != null)
                    {
                        sqlTransaction.Commit();
                    }
                }
                catch (Exception exception)
                {
                    if (sqlTransaction != null)
                    {
                        sqlTransaction.Rollback();
                    }

                    throw (exception);
                }
            }
        }
    }
}

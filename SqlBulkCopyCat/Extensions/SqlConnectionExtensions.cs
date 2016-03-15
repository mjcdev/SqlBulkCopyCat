using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;

namespace SqlBulkCopyCat.Extensions
{
    internal static class SqlConnectionExtensions
    {
        public static SqlTransaction BeginTransaction(this SqlConnection sqlConnection, SqlBulkCopyCatConfig sqlBulkCopyCatConfig)
        {
            SqlTransaction sqlTransaction = null;

            if (sqlBulkCopyCatConfig != null && sqlBulkCopyCatConfig.SqlTransaction.HasValue && sqlBulkCopyCatConfig.SqlTransaction.Value)
            {
                sqlTransaction = sqlConnection.BeginTransaction();
            }

            return sqlTransaction;
        }
    }
}

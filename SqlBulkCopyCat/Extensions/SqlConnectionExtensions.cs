using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;

namespace SqlBulkCopyCat.Extensions
{
    internal static class SqlConnectionExtensions
    {
        public static SqlTransaction BeginTransaction(this SqlConnection sqlConnection, CopyCatConfig copyCatConfig)
        {
            SqlTransaction sqlTransaction = null;

            if (copyCatConfig != null && copyCatConfig.SqlTransaction.HasValue && copyCatConfig.SqlTransaction.Value)
            {
                sqlTransaction = sqlConnection.BeginTransaction();
            }

            return sqlTransaction;
        }
    }
}

using System.Data.SqlClient;

namespace SqlBulkCopyCat.Model.Config
{
    public class SqlBulkCopySettings
    {
        public int? BatchSize { get; set; }

        public int? BulkCopyTimeout { get; set; }

        public bool? EnableStreaming { get; set; }

        public int? NotifyAfter { get; set; }

        public int? SqlBulkCopyOptions { get; set; }

        public int? SetSqlBulkCopyOptions(SqlBulkCopyOptions sqlBulkCopyOptions)
        {
            var sqlBulkCopyOptionsNullableInt =  (int?)sqlBulkCopyOptions;

            SqlBulkCopyOptions = sqlBulkCopyOptionsNullableInt;

            return sqlBulkCopyOptionsNullableInt;
        }

        public SqlBulkCopyOptions GetSqlBulkCopyOptions()
        {
            if (SqlBulkCopyOptions.HasValue)
            {
                return (SqlBulkCopyOptions)SqlBulkCopyOptions;
            }

            return System.Data.SqlClient.SqlBulkCopyOptions.Default;            
        }
    }
}

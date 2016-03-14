using System;
using System.Data.SqlClient;

namespace SqlBulkCopyCat.Model.Config
{
    [Serializable]
    public class ColumnMapping
    {
        private SqlBulkCopyColumnMapping _sqlBulkCopyColumnMapping;

        public string Source { get; set; }
        public string Destination { get; set; }

        internal SqlBulkCopyColumnMapping BuildSqlBulkCopyColumnMapping()
        {
            if (_sqlBulkCopyColumnMapping == null)
            {
                _sqlBulkCopyColumnMapping = new SqlBulkCopyColumnMapping(Source, Destination); 
            }

            return _sqlBulkCopyColumnMapping;
        }
    }
}

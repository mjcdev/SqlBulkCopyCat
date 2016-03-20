using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlBulkCopyCat.Model.Config
{
    [Serializable]
    public class TableMapping
    {
        private const string SelectWildCard = "*";
        private const string ColumnSeperator = ", ";

        private List<ColumnMapping> _columnMappings = new List<ColumnMapping>();
        private int _ordinal = 0;

        public string Source { get; set; }

        public string Destination { get; set; }

        public int Ordinal
        {
            get
            {
                return _ordinal;
            }
            set
            {
                _ordinal = value;
            }
        }

        public List<ColumnMapping> ColumnMappings
        {
            get
            {
                return _columnMappings ?? new List<ColumnMapping>();
            }
            set
            {
                _columnMappings = value;
            }
        }

        internal string BuildSelectSql()
        {
            var columns = BuildSelectSqlColumns();

            return string.Format("SELECT {0} FROM {1}", columns, Source);
        }

        private string BuildSelectSqlColumns()
        {
            if (!ColumnMappings.Any())
            {
                return SelectWildCard;
            }

            var columnCount = ColumnMappings.Count();

            var columnsBuilder = new StringBuilder();

            for (int i = 0; i < columnCount - 1; i++)
            {
                columnsBuilder.Append(ColumnMappings[i].Source);
                columnsBuilder.Append(ColumnSeperator);
            }

            columnsBuilder.Append(ColumnMappings[columnCount - 1].Source);

            return columnsBuilder.ToString();
        }
    }
}

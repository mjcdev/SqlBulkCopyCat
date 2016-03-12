using System;
using System.Collections.Generic;

namespace SqlBulkCopyCat.Model
{
    [Serializable]
    public class TableMapping
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public List<ColumnMapping> ColumnMappings { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SqlBulkCopyCat.Model
{
    [Serializable]
    public class SqlBulkCopyCatConfig
    {
        public List<TableMapping> TableMappings { get; set; }
    }
}

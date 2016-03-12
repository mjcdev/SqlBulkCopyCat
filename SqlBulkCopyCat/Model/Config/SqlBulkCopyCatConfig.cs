using System;
using System.Collections.Generic;

namespace SqlBulkCopyCat.Model.Config
{
    [Serializable]
    public class SqlBulkCopyCatConfig
    {
        public string SourceConnectionString { get; set; }        
        public string DestinationConnectionString { get; set; }

        public List<TableMapping> TableMappings { get; set; }    
    }
}

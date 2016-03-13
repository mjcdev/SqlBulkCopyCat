using System;
using System.Collections.Generic;

namespace SqlBulkCopyCat.Model.Config
{
    [Serializable]
    public class SqlBulkCopyCatConfig
    {
        private List<TableMapping> _tableMappings = new List<TableMapping>();

        public string SourceConnectionString { get; set; }        
        public string DestinationConnectionString { get; set; }

        public List<TableMapping> TableMappings
        {
            get
            {
                return _tableMappings ?? new List<TableMapping>();
            }
            set
            {
                _tableMappings = value;
            }
        }    
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SqlBulkCopyCat.Model.Config
{
    [Serializable]
    public class CopyCatConfig
    {
        private List<TableMapping> _tableMappings = new List<TableMapping>();

        internal string _sourceConnectionString;

        internal string _destinationConnectionString;

        public string SourceConnectionString
        {
            get
            {
                return OverrideInitialCatalog(_sourceConnectionString, SourceInitialCatalog);
            }
            set
            {
                _sourceConnectionString = value;
            }
        }

        public string DestinationConnectionString
        {
            get
            {
                return OverrideInitialCatalog(_destinationConnectionString, DestinationInitialCatalog);
            }
            set
            {
                _destinationConnectionString = value;
            }
        }

        public string SourceInitialCatalog { get; set; }

        public string DestinationInitialCatalog { get; set; }

        public SqlBulkCopySettings SqlBulkCopySettings { get; set; }

        public bool? SqlTransaction { get; set; }

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
        
        private string OverrideInitialCatalog(string baseConnectionString, string overrideInitialCatalog)
        {
            if (overrideInitialCatalog != null)
            {
                var connectionString = new SqlConnectionStringBuilder(baseConnectionString);
                connectionString.InitialCatalog = overrideInitialCatalog;

                return connectionString.ToString();
            }

            return baseConnectionString;
        }   
    }
}

using Dapper;
using SqlBulkCopyCat.Model.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlBulkCopyCat
{
    public class SqlBulkCopyCat
    {
        private readonly SqlBulkCopyCatConfig _config;

        public SqlBulkCopyCatConfig Config
        {
            get
            {
                return _config;
            }
        }

        public SqlBulkCopyCat(SqlBulkCopyCatConfig sqlBulkCopyCatConfig)
        {
            _config = sqlBulkCopyCatConfig;
        }

        public void Copy()
        {
            using (var writeConnection = new SqlConnection(Config.DestinationConnectionString))
            {
                foreach(var tableMapping in Config.TableMappings)
                {
                    using (var readConnection = new SqlConnection(Config.SourceConnectionString))                    
                    using (var reader = readConnection.ExecuteReader(string.Format("SELECT * FROM {0}", tableMapping.Source)))
                    using (var bcp = new SqlBulkCopy(writeConnection))
                    {
                        writeConnection.Open();
                        bcp.DestinationTableName = tableMapping.Destination;
                        bcp.WriteToServer(reader);
                    }                    
                }
            }
        }
    }
}

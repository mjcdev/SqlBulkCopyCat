using Dapper;
using SqlBulkCopyCat.Builder;
using SqlBulkCopyCat.Model.Config;
using System.Data.SqlClient;
using System.Linq;

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
                    using (var reader = readConnection.ExecuteReader(tableMapping.BuildSelectSql()))
                    using (var bcp = SqlBulkCopyBuilder.Build(writeConnection, tableMapping))
                    {
                        writeConnection.Open();

                        bcp.WriteToServer(reader);
                    }                    
                }
            }
        }
    }
}

using Newtonsoft.Json;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using System.IO;

namespace SqlBulkCopyCat.Model.Config.Deserialization.Json
{
    internal class SqlBulkCopyCatConfigJsonFileDeserializer : ISqlBulkCopyCatConfigDeserializer
    {
        public SqlBulkCopyCatConfig Deserialize(string input)
        {
            var jsonDeserializer = new JsonSerializer();

            var json = File.ReadAllText(input);

            return JsonConvert.DeserializeObject<SqlBulkCopyCatConfig>(json);              
        }
    }
}

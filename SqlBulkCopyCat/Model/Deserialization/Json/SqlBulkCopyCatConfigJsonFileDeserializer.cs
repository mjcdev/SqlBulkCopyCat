using Newtonsoft.Json;
using SqlBulkCopyCat.Model.Deserialization.Interfaces;
using System;
using System.IO;

namespace SqlBulkCopyCat.Model.Deserialization.Json
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

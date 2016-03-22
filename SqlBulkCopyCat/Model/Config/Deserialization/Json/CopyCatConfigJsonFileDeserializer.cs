using Newtonsoft.Json;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using System.IO;

namespace SqlBulkCopyCat.Model.Config.Deserialization.Json
{
    internal class CopyCatConfigJsonFileDeserializer : ICopyCatConfigDeserializer
    {
        public CopyCatConfig Deserialize(string input)
        {
            var jsonDeserializer = new JsonSerializer();

            var json = File.ReadAllText(input);

            return JsonConvert.DeserializeObject<CopyCatConfig>(json);              
        }
    }
}

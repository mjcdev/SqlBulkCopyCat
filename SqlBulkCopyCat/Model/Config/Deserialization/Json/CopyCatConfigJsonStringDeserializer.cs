using Newtonsoft.Json;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using System.IO;

namespace SqlBulkCopyCat.Model.Config.Deserialization.Json
{
    internal class CopyCatConfigJsonStringDeserializer : ICopyCatConfigDeserializer
    {
        public CopyCatConfig Deserialize(string input)
        {
            return JsonConvert.DeserializeObject<CopyCatConfig>(input);              
        }
    }
}

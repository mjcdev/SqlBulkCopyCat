using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace SqlBulkCopyCat.Model.Config.Deserialization.Xml
{
    internal class CopyCatConfigXmlFileDeserializer : ICopyCatConfigDeserializer
    {
        public CopyCatConfig Deserialize(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(CopyCatConfig));

            using (var fileStream = new FileStream(input, FileMode.Open))
            {
                return (CopyCatConfig)xmlSerializer.Deserialize(fileStream);
            }
        }
    }
}

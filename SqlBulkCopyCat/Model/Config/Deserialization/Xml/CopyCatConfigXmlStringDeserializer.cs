using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace SqlBulkCopyCat.Model.Config.Deserialization.Xml
{
    internal class CopyCatConfigXmlStringDeserializer : ICopyCatConfigDeserializer
    {
        public CopyCatConfig Deserialize(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(CopyCatConfig));

            using (var stream = MemoryStreamFromString(input))
            {
                return (CopyCatConfig)xmlSerializer.Deserialize(stream);
            }
        }

        private MemoryStream MemoryStreamFromString(string input)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(input);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}

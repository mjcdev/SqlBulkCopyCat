using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Json;
using SqlBulkCopyCat.Model.Config.Deserialization.Xml;

namespace SqlBulkCopyCat.Model.Config.Builder
{
    public class CopyCatConfigBuilder
    {
        private ICopyCatConfigDeserializer _xmlFileDeserializer;
        private ICopyCatConfigDeserializer _jsonFileDeserializer;

        private CopyCatConfig _config = new CopyCatConfig();

        public CopyCatConfig Config
        {
            get
            {
                return _config;
            }
            private set
            {
                _config = value;
            }
        }

        public CopyCatConfigBuilder()
            : this(new CopyCatConfigXmlFileDeserializer(), new CopyCatConfigJsonFileDeserializer())
        {
        }

        internal CopyCatConfigBuilder(ICopyCatConfigDeserializer xmlFileDeserializer, ICopyCatConfigDeserializer jsonFileDeserializer)
        {
            _xmlFileDeserializer = xmlFileDeserializer;
            _jsonFileDeserializer = jsonFileDeserializer;
        }

        public CopyCatConfig FromXmlFile(string filePath)
        {
            Config = _xmlFileDeserializer.Deserialize(filePath);
            return Config;
        }

        public CopyCatConfig FromJsonFile(string filePath)
        {
            Config = _jsonFileDeserializer.Deserialize(filePath);
            return Config;
        }
    }
}

using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Json;
using SqlBulkCopyCat.Model.Config.Deserialization.Xml;

namespace SqlBulkCopyCat.Model.Config.Builder
{
    public class CopyCatConfigBuilder
    {
        private ICopyCatConfigDeserializer _xmlFileDeserializer;
        private ICopyCatConfigDeserializer _jsonFileDeserializer;
        private ICopyCatConfigDeserializer _xmlStringDeserializer;
        private ICopyCatConfigDeserializer _jsonStringDeserializer;

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
            : this(new CopyCatConfigXmlFileDeserializer(),
                  new CopyCatConfigJsonFileDeserializer(),
                  new CopyCatConfigXmlStringDeserializer(),
                  new CopyCatConfigJsonStringDeserializer())
        {
        }

        internal CopyCatConfigBuilder(ICopyCatConfigDeserializer xmlFileDeserializer,
            ICopyCatConfigDeserializer jsonFileDeserializer,
            ICopyCatConfigDeserializer xmlStringDeserializer,
            ICopyCatConfigDeserializer jsonStringDeserializer)
        {
            _xmlFileDeserializer = xmlFileDeserializer;
            _jsonFileDeserializer = jsonFileDeserializer;
            _xmlStringDeserializer = xmlStringDeserializer;
            _jsonStringDeserializer = jsonStringDeserializer;
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

        public CopyCatConfig FromXmlString(string xmlString)
        {
            Config = _xmlStringDeserializer.Deserialize(xmlString);
            return Config;
        }

        public CopyCatConfig FromJsonString(string jsonString)
        {
            Config = _jsonStringDeserializer.Deserialize(jsonString);
            return Config;
        }
    }
}

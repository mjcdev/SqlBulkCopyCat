using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using SqlBulkCopyCat.Model.Config.Deserialization.Json;
using SqlBulkCopyCat.Model.Config.Deserialization.Xml;

namespace SqlBulkCopyCat.Model.Config.Builder
{
    public class SqlBulkCopyCatConfigBuilder
    {
        private ISqlBulkCopyCatConfigDeserializer _xmlFileDeserializer;
        private ISqlBulkCopyCatConfigDeserializer _jsonFileDeserializer;

        private SqlBulkCopyCatConfig _config = new SqlBulkCopyCatConfig();

        public SqlBulkCopyCatConfig Config
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

        public SqlBulkCopyCatConfigBuilder()
            : this(new SqlBulkCopyCatConfigXmlFileDeserializer(), new SqlBulkCopyCatConfigJsonFileDeserializer())
        {
        }

        internal SqlBulkCopyCatConfigBuilder(ISqlBulkCopyCatConfigDeserializer xmlFileDeserializer, ISqlBulkCopyCatConfigDeserializer jsonFileDeserializer)
        {
            _xmlFileDeserializer = xmlFileDeserializer;
            _jsonFileDeserializer = jsonFileDeserializer;
        }

        public SqlBulkCopyCatConfig FromXmlFile(string filePath)
        {
            Config = _xmlFileDeserializer.Deserialize(filePath);
            return Config;
        }

        public SqlBulkCopyCatConfig FromJsonFile(string filePath)
        {
            Config = _jsonFileDeserializer.Deserialize(filePath);
            return Config;
        }
    }
}

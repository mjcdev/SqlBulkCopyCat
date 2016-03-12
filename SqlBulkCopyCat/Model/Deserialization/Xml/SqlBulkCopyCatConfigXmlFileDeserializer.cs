﻿using SqlBulkCopyCat.Model.Deserialization.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace SqlBulkCopyCat.Model.Deserialization.Xml
{
    internal class SqlBulkCopyCatConfigXmlFileDeserializer : ISqlBulkCopyCatConfigDeserializer
    {
        public SqlBulkCopyCatConfig Deserialize(string input)
        {
            var xmlSerializer = new XmlSerializer(typeof(SqlBulkCopyCatConfig));

            using (var fileStream = new FileStream(input, FileMode.Open))
            {
                return (SqlBulkCopyCatConfig)xmlSerializer.Deserialize(fileStream);
            }
        }
    }
}

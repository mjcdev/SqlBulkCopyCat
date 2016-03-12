namespace SqlBulkCopyCat.Model.Config.Deserialization.Interfaces
{
    internal interface ISqlBulkCopyCatConfigDeserializer
    {
        SqlBulkCopyCatConfig Deserialize(string input);
    }
}

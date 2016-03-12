namespace SqlBulkCopyCat.Model.Deserialization.Interfaces
{
    internal interface ISqlBulkCopyCatConfigDeserializer
    {
        SqlBulkCopyCatConfig Deserialize(string input);
    }
}

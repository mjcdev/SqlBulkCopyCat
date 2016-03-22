namespace SqlBulkCopyCat.Model.Config.Deserialization.Interfaces
{
    internal interface ICopyCatConfigDeserializer
    {
        CopyCatConfig Deserialize(string input);
    }
}

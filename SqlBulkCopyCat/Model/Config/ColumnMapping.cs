using System;

namespace SqlBulkCopyCat.Model.Config
{
    [Serializable]
    public class ColumnMapping
    {
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}

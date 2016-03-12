using System;

namespace SqlBulkCopyCat.Model
{
    [Serializable]
    public class ColumnMapping
    {
        public string Source { get; set; }
        public string Destination { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlBulkCopyCat.Model.Config
{
    public class SqlBulkCopySettings
    {
        public int? BatchSize { get; set; }

        public int? Timeout { get; set; }

        public bool? EnableStreaming { get; set; }
    }
}

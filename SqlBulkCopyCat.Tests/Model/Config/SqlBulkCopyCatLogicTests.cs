using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Config
{
    public class SqlBulkCopyCatLogicTests
    {
        [Fact]
        public void NullCoalesceTableMappings_Null()
        {
            var config = new SqlBulkCopyCatConfig { TableMappings = null };

            config.TableMappings.Should().HaveCount(0);
            config.TableMappings.Should().NotBeNull();
        }

        [Fact]
        public void NullCoalesceColumnMappings_NotNull()
        {
            var config = new SqlBulkCopyCatConfig
            {
                TableMappings = new List<TableMapping>
                {
                    new TableMapping()
                }
            };

            config.TableMappings.Should().HaveCount(1);
            config.TableMappings.Should().NotBeNull();
        }
    }
}

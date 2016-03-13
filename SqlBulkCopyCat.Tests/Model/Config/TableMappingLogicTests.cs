using FluentAssertions;
using SqlBulkCopyCat.Model.Config;
using System.Collections.Generic;
using Xunit;

namespace SqlBulkCopyCat.Tests.Model.Config
{
    public class TableMappingLogicTests
    {
        [Fact]
        public void BuildSelectSql_NoColumnMappings()
        {
            var tableMapping = new TableMapping { Source = "TableName" };

            tableMapping.BuildSelectSql().Should().Be("SELECT * FROM TableName");            
        }

        [Fact]
        public void BuildSelectSql_OneColumnMapping()
        {
            var tableMapping = new TableMapping
            {
                Source = "TableName",
                ColumnMappings = new List<ColumnMapping>
                {
                    new ColumnMapping { Source = "SourceColumn" }
                }
            };

            tableMapping.BuildSelectSql().Should().Be("SELECT SourceColumn FROM TableName");
        }

        [Fact]
        public void BuildSelectSql_TwoColumnMappings()
        {
            var tableMapping = new TableMapping
            {
                Source = "TableName",
                ColumnMappings = new List<ColumnMapping>
                {
                    new ColumnMapping { Source = "SourceColumnOne" },
                    new ColumnMapping { Source = "SourceColumnTwo" }
                }
            };

            tableMapping.BuildSelectSql().Should().Be("SELECT SourceColumnOne, SourceColumnTwo FROM TableName");
        }

        [Fact]
        public void BuildSelectSql_FiveColumnMappings()
        {
            var tableMapping = new TableMapping
            {
                Source = "TableName",
                ColumnMappings = new List<ColumnMapping>
                {
                    new ColumnMapping { Source = "SourceColumnOne" },
                    new ColumnMapping { Source = "SourceColumnTwo" },
                    new ColumnMapping { Source = "SourceColumnThree" },
                    new ColumnMapping { Source = "SourceColumnFour" },
                    new ColumnMapping { Source = "SourceColumnFive" }
                }
            };

            tableMapping.BuildSelectSql().Should().Be("SELECT SourceColumnOne, SourceColumnTwo, SourceColumnThree, SourceColumnFour, SourceColumnFive FROM TableName");
        }

        [Fact]
        public void BuildSelectSql_dboTable()
        {
            var tableMapping = new TableMapping { Source = "TableName" };

            tableMapping.BuildSelectSql().Should().Be("SELECT * FROM TableName");
        }    

        [Fact]
        public void BuildSelectSql_SchemaTable()
        {
            var tableMapping = new TableMapping { Source = "Schema.TableName" };

            tableMapping.BuildSelectSql().Should().Be("SELECT * FROM Schema.TableName");
        }

        [Fact]
        public void NullCoalesceColumnMappings_Null()
        {
            var tableMapping = new TableMapping { ColumnMappings = null };

            tableMapping.ColumnMappings.Should().HaveCount(0);
            tableMapping.ColumnMappings.Should().NotBeNull();
        }

        [Fact]
        public void NullCoalesceColumnMappings_NotNull()
        {
            var tableMapping = new TableMapping
            {
                ColumnMappings = new List<ColumnMapping>
                {
                    new ColumnMapping()
                }
            };

            tableMapping.ColumnMappings.Should().HaveCount(1);
            tableMapping.ColumnMappings.Should().NotBeNull();
        }
    }
}

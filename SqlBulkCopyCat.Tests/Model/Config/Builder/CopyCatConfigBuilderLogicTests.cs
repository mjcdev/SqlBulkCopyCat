using SqlBulkCopyCat.Model.Config;
using SqlBulkCopyCat.Model.Config.Builder;
using SqlBulkCopyCat.Model.Config.Deserialization.Interfaces;
using Xunit;
using Moq;
using FluentAssertions;

namespace SqlBulkCopyCat.Tests.Model
{
    public class CopyCatConfigBuilderLogicTests
    {
        private const string FilePath = "FilePath";

        [Fact]
        public void FromXmlFile()
        {            
            var config = new CopyCatConfig();
            var mock = new Mock<ICopyCatConfigDeserializer>();
            mock.Setup(ds => ds.Deserialize(FilePath)).Returns(config);
            ICopyCatConfigDeserializer mockDeserializer = mock.Object;

            var builder = new CopyCatConfigBuilder(mockDeserializer, null);

            var actual = builder.FromXmlFile(FilePath);
            
            actual.Should().BeSameAs(config);
            builder.Config.Should().BeSameAs(config);

            mock.Verify(ds => ds.Deserialize(FilePath), Times.Once);
        }

        [Fact]
        public void FromJsonFile()
        {
            var config = new CopyCatConfig();
            var mock = new Mock<ICopyCatConfigDeserializer>();
            mock.Setup(ds => ds.Deserialize(FilePath)).Returns(config);
            ICopyCatConfigDeserializer mockDeserializer = mock.Object;

            var builder = new CopyCatConfigBuilder(null, mockDeserializer);

            var actual = builder.FromJsonFile(FilePath);

            actual.Should().BeSameAs(config);
            builder.Config.Should().BeSameAs(config);

            mock.Verify(ds => ds.Deserialize(FilePath), Times.Once);
        }
    }
}

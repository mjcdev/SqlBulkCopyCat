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
        private const string StringInput = "String Input";

        [Fact]
        public void FromXmlFile()
        {            
            var config = new CopyCatConfig();
            var mock = new Mock<ICopyCatConfigDeserializer>();
            mock.Setup(ds => ds.Deserialize(FilePath)).Returns(config);
            ICopyCatConfigDeserializer mockDeserializer = mock.Object;

            var builder = new CopyCatConfigBuilder(mockDeserializer, null, null, null);

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

            var builder = new CopyCatConfigBuilder(null, mockDeserializer, null, null);

            var actual = builder.FromJsonFile(FilePath);

            actual.Should().BeSameAs(config);
            builder.Config.Should().BeSameAs(config);

            mock.Verify(ds => ds.Deserialize(FilePath), Times.Once);
        }

        [Fact]
        public void FromXmlString()
        {
            var config = new CopyCatConfig();
            var mock = new Mock<ICopyCatConfigDeserializer>();
            mock.Setup(ds => ds.Deserialize(FilePath)).Returns(config);
            ICopyCatConfigDeserializer mockDeserializer = mock.Object;

            var builder = new CopyCatConfigBuilder(null, null, mockDeserializer, null);

            var actual = builder.FromXmlString(StringInput);

            actual.Should().BeSameAs(config);
            builder.Config.Should().BeSameAs(config);

            mock.Verify(ds => ds.Deserialize(StringInput), Times.Once);
        }

        [Fact]
        public void FromJsonString()
        {
            var config = new CopyCatConfig();
            var mock = new Mock<ICopyCatConfigDeserializer>();
            mock.Setup(ds => ds.Deserialize(FilePath)).Returns(config);
            ICopyCatConfigDeserializer mockDeserializer = mock.Object;

            var builder = new CopyCatConfigBuilder(null, null, null, mockDeserializer);

            var actual = builder.FromJsonString(StringInput);

            actual.Should().BeSameAs(config);
            builder.Config.Should().BeSameAs(config);

            mock.Verify(ds => ds.Deserialize(StringInput), Times.Once);
        }
    }
}

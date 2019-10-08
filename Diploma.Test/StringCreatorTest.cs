using Diploma.Utils;
using Diploma.Wrappers;
using FluentAssertions;
using Moq;
using Xunit;

namespace Diploma.Test
{
    public class StringCreatorTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("NAME", "SURNAME")]
        [InlineData(null, null)]
        public void GetFirstParagraph_Strings_ReturnsParagraphString(string name, string surname)
        {
            var constantsMock = new Mock<IConstants>();
            constantsMock.Setup(x => x.GetDiplomNameText).Returns("DIPLOMA");
            var domainWrapperMock = new Mock<IDomainWrapper>();
            domainWrapperMock.Setup(x => x.GetRoothDirectory()).Returns("/");
            var sut = new StringCreator(constantsMock.Object, domainWrapperMock.Object);

            var actual = sut.GetFirstParagraph(name, surname);

            actual.Should().Be("DIPLOMA\n" + name + " " + surname);
        }
        
        [Fact]
        public void CreatePath_ValidName_ReturnsFilePath()
        {
            var constantsMock = new Mock<IConstants>();
            constantsMock.Setup(x => x.GetExtension).Returns(".txt");
            var domainWrapperMock = new Mock<IDomainWrapper>();
            domainWrapperMock.Setup(x => x.GetRoothDirectory()).Returns("/");
            var sut = new StringCreator(constantsMock.Object, domainWrapperMock.Object);

            var actual = sut.CreatePath("Ion", "Ion");

            actual.Should().Be("/IonIon.txt");
        }
    }
}
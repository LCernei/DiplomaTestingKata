using Diploma.Models;
using Diploma.Tests.Builder;
using Diploma.Wrappers;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace Diploma.Tests.UnitTests
{
    public class StringCreatorTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("name", "surname")]
        [InlineData(null, null)]
        public void CreatePath_ReturnsFilePath_WithNameAndSurname(string name, string surname)
        {
            var constants = Substitute.For<IConstants>();
            constants.GetExtension.Returns(".txt");

            var domainWrapper = Substitute.For<IDomainWrapper>();
            domainWrapper.GetRoothDirectory().Returns("/root/");

            var expected = domainWrapper.GetRoothDirectory() + name + surname + constants.GetExtension;
            var sut = new StringCreatorBuilder().WithConstants(constants).WithDomainWrapper(domainWrapper).Build();

            var actual = sut.CreatePath(name, surname);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("name", "surname")]
        [InlineData(null, null)]
        public void GetFirstParagraph_ReturnsParagraph_WithNameAndSurname(string name, string surname)
        {
            var constants = Substitute.For<IConstants>();
            constants.GetDiplomNameText.Returns("diploma");

            var expected = constants.GetDiplomNameText + "\n" + name + " " + surname;
            var sut = new StringCreatorBuilder().WithConstants(constants).Build();

            var actual = sut.GetFirstParagraph(name, surname);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("subjectName", 4)]
        [InlineData(null, -1)]
        public void GetSecondParagraphText_ReturnsText_WithOneSubject(string subjectName, int grade)
        {
            var grades = new List<Subject> { new Subject { SubjectName = subjectName, Grade = grade } };

            var expected = subjectName + " " + grade + "\n";
            var sut = new StringCreatorBuilder().Build();

            var actual = sut.GetSecondParagraphText(grades);

            Assert.Equal(expected, actual);
        }
    }
}

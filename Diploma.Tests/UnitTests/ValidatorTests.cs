using Diploma.Models;
using Diploma.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;

namespace Diploma.Tests.UnitTests
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData(null, "secondname")]
        [InlineData("firstname", "")]
        public void ValidateStudentRecord_ReturnsFalse_WithInvalidName(string firstName, string lastName)
        {
            var grades = new List<Subject> { new Subject { Grade = 2, SubjectName = "subject" } };
            var studentModel = new StudentModel { FirstName = firstName, LastName = lastName, Grades = grades};

            var sut = new Validator();

            var actual = sut.ValidateStudentRecord(studentModel);
            
            Assert.False(actual);
        }

        [Theory]
        [InlineData(-1, "subjectName")]
        [InlineData(11, "subjectName")]
        [InlineData(5, null)]
        public void ValidateStudentRecord_ReturnsFalse_WithInvalidSubject(int grade, string subjectName)
        {
            var grades = new List<Subject> { new Subject { Grade = grade, SubjectName = subjectName } };
            var studentModel = new StudentModel { FirstName = "firstname", LastName = "lastname", Grades = grades};

            var sut = new Validator();

            var actual = sut.ValidateStudentRecord(studentModel);

            Assert.False(actual);
        }

        [Fact]
        public void ValidateStudentRecord_ReturnsTrue_WithoutSubjects()
        {
            var grades = new List<Subject>();
            var studentModel = new StudentModel { FirstName = "firstname", LastName = "lastname", Grades = grades };

            var sut = new Validator();
            
            var actual = sut.ValidateStudentRecord(studentModel);

            Assert.True(actual);
        }

        [Fact]
        public void ValidateStudentRecord_ReturnsTrue_WithValidData()
        {
            var grades = Substitute.For<IEnumerable<Subject>>();
            var studentModel = Substitute.For<StudentModel>();

            var sut = new Validator();

            var actual = sut.ValidateStudentRecord(studentModel);

            Assert.False(actual);
        }
    }
}

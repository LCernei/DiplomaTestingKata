using System.Collections.Generic;
using Diploma.Models;
using Diploma.Utils;
using Xunit;
using FluentAssertions;

namespace Diploma.Tests.UnitTests
{
    public class CustomMapperTests
    {
        [Fact]
        public void MapToStudent_ReturnsCorrectList_WithValidData()
        {
            var studentRawModel = new StudentRawModel
            {
                Nume = "nume",
                Prenume = "prenume",
                Biologia = 1,
                Chimia = 2,
                Fizica = 3,
                Geografia = 4,
                Informatica = 5,
                Istoria = 6,
                LimbaEngleza = 7,
                LimbaRomana = 8,
                Matematica = 9,
            };
            var grades = new List<Subject>
            {
                new Subject {SubjectName = "Biologia", Grade = 1},
                new Subject {SubjectName = "Chimia", Grade = 2},
                new Subject {SubjectName = "Fizica", Grade = 3},
                new Subject {SubjectName = "Geografia", Grade = 4},
                new Subject {SubjectName = "Informatica", Grade = 5},
                new Subject {SubjectName = "Istoria", Grade = 6},
                new Subject {SubjectName = "LimbaEngleza", Grade = 7},
                new Subject {SubjectName = "LimbaRomana", Grade = 8},
                new Subject {SubjectName = "Matematica", Grade = 9}
            };
            var studentModel = new StudentModel
            {
                FirstName = "prenume",
                LastName = "nume",
                Grades = grades
            };
            
            var rawModels = new List<StudentRawModel> {studentRawModel};
            var expected = new List<StudentModel> {studentModel};
            var sut = new CustomMapper();

            var actual = sut.MapToStudent(rawModels);
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
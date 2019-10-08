using Diploma.Files;
using Diploma.Models;
using Diploma.Tests.Builder;
using Diploma.Utils;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace Diploma.Tests.UnitTests
{
    public class StudentDataProcessorTests
    {
        [Fact]
        public void LoadData_CallsImportData_OneTimeWithPath()
        {
            string path = "path";
            var fileReader = Substitute.For<IFileReader>();
            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).Build();

            sut.LoadData(path);
            fileReader.Received(1).ImportData(path);
        }

        [Fact]
        public void LoadData_CallsMapToStudent_WithStudentsFromImportData()
        {
            string path = "path";
            var students = new List<StudentRawModel>() { new StudentRawModel()};
            var fileReader = Substitute.For<IFileReader>();
            fileReader.ImportData(path).Returns(students);

            var mapper = Substitute.For<ICustomMapper>();
            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).Build();

            sut.LoadData(path);
            mapper.Received(1).MapToStudent(students);
        }
    }
}
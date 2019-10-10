using Diploma.Files;
using Diploma.Models;
using Diploma.Tests.Builder;
using Diploma.Utils;
using Diploma.Validators;
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
            const string path = "path";
            var fileReader = Substitute.For<IFileReader>();
            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).Build();

            sut.LoadData(path);
            fileReader.Received(1).ImportData(path);
        }

        [Fact]
        public void LoadData_CallsMapToStudent_WithStudentsFromImportData()
        {
            const string path = "path";
            var students = new List<StudentRawModel>() { new StudentRawModel() };
            var fileReader = Substitute.For<IFileReader>();
            fileReader.ImportData(path).Returns(students);

            var mapper = Substitute.For<ICustomMapper>();
            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).Build();

            sut.LoadData(path);
            mapper.Received(1).MapToStudent(students);
        }

        [Fact]
        public void LoadData_CallsValidator_WithAnyStudents()
        {
            const string path = "path";

            var fileReader = Substitute.For<IFileReader>();
            var studentRawModels = new List<StudentRawModel> { new StudentRawModel(), new StudentRawModel() };
            var studentModels = new List<StudentModel> { new StudentModel(), new StudentModel() };
            fileReader.ImportData(path).Returns(studentRawModels);

            var mapper = Substitute.For<ICustomMapper>();
            mapper.MapToStudent(studentRawModels).Returns(studentModels);

            var validator = Substitute.For<IValidator>();

            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).WithValidator(validator).Build();
            sut.LoadData(path);

            validator.ReceivedWithAnyArgs(studentModels.Count).ValidateStudentRecord(default);
        }

        [Fact]
        public void LoadData_CallsCreateDiplomas_WithAnyStudents()
        {
            const string path = "path";

            var fileReader = Substitute.For<IFileReader>();
            var students = new List<StudentRawModel> { new StudentRawModel(), new StudentRawModel() };
            var studentModels = new List<StudentModel> { new StudentModel(), new StudentModel() };
            fileReader.ImportData(path).Returns(students);

            var mapper = Substitute.For<ICustomMapper>();
            mapper.MapToStudent(students).Returns(studentModels);

            var validator = Substitute.For<IValidator>();
            validator.ValidateStudentRecord(default).ReturnsForAnyArgs(true);

            var fileWriter = Substitute.For<IFileWriter>();

            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).WithValidator(validator).WithFileWriter(fileWriter).Build();
            sut.LoadData(path);

            fileWriter.ReceivedWithAnyArgs(studentModels.Count).CreateDiplomas(default);
        }

        [Fact]
        public void LoadData_CallsSaveDiploma_WithAnyStudents()
        {
            const string path = "path";

            var fileReader = Substitute.For<IFileReader>();
            var students = new List<StudentRawModel> { new StudentRawModel(), new StudentRawModel() };
            var studentModels = new List<StudentModel> { new StudentModel(), new StudentModel() };
            fileReader.ImportData(path).Returns(students);

            var mapper = Substitute.For<ICustomMapper>();
            mapper.MapToStudent(students).Returns(studentModels);

            var validator = Substitute.For<IValidator>();
            validator.ValidateStudentRecord(default).ReturnsForAnyArgs(true);

            var fileWriter = Substitute.For<IFileWriter>();

            var sut = new StudentDataProcessorBuilder().WithFileReader(fileReader).WithMapper(mapper).WithValidator(validator).WithFileWriter(fileWriter).Build();
            sut.LoadData(path);

            fileWriter.ReceivedWithAnyArgs(studentModels.Count).SaveDiploma(default, default, default);
        }
    }
}
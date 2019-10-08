using Diploma.Models;
using Diploma.Validators;
using System;
using FluentAssertions;
using Xunit;

namespace Diploma.Test
{
    public class ValidatorTest
    {
        [Fact]
        public void ValidateStudentRecord_EmptyName_ReturnsFalse()
        {
            var obj = new Validator();
            var studentModel = new StudentModel();
            
            var actual = obj.ValidateStudentRecord(studentModel);
            
            actual.Should().Be(false);
        }
        
        [Fact]
        public void ValidateStudentRecord_NoGrades_ReturnsFalse()
        {
            var obj = new Validator();
            var studentModel = new StudentModel {FirstName = "Ion", LastName = "Ion"};

            var actual = obj.ValidateStudentRecord(studentModel);
            
            actual.Should().Be(false);
        }
    }
}

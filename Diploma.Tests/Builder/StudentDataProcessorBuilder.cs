using Diploma.DataProcessing;
using Diploma.Files;
using Diploma.Utils;
using Diploma.Validators;
using NSubstitute;

namespace Diploma.Tests.Builder
{
    public class StudentDataProcessorBuilder
    {
        private IFileReader _fileReader;
        private ICustomMapper _mapper;
        private IFileWriter _fileWriter;
        private IValidator _validator;

        public StudentDataProcessorBuilder()
        {
            this._fileReader = Substitute.For<IFileReader>();
            this._mapper = Substitute.For<ICustomMapper>();
            this._fileWriter = Substitute.For<IFileWriter>();
            this._validator = Substitute.For<IValidator>();
        }

        public StudentDataProcessorBuilder WithFileReader(IFileReader fileReader)
        {
            this._fileReader = fileReader;
            return this;
        }

        public StudentDataProcessorBuilder WithMapper(ICustomMapper mapper)
        {
            this._mapper = mapper;
            return this;
        }

        public StudentDataProcessorBuilder WithFileWriter(IFileWriter fileWriter)
        {
            this._fileWriter = fileWriter;
            return this;
        }

        public StudentDataProcessorBuilder WithValidator(IValidator validator)
        {
            this._validator = validator;
            return this;
        }

        public StudentDataProcessor Build()
        {
            return new StudentDataProcessor(_fileReader, _mapper, _fileWriter, _validator);
        }
    }
}
using Diploma.DataProcessing;
using Diploma.Files;
using Diploma.Utils;
using Diploma.Validators;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Diploma.Tests.UnitTests
{
    public class MainMenuTests
    {
        [Fact]
        public void CollectData_CallsLoadData_OneTimeWithEnter()
        {
            const string path = "path";
            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            consoleWrapper.ReadLine().Returns(path);
            consoleWrapper.ReadKey().Returns(new ConsoleKeyInfo('\n', ConsoleKey.Enter, false, false, false));

            var constants = Substitute.For<IConstants>();
            var studentDataProcessor = Substitute.For<IStudentDataProcessor>();

            var sut = new MainMenu(consoleWrapper, constants, studentDataProcessor);

            sut.CollectData();

            studentDataProcessor.Received(1).LoadData(path);
        }

        [Fact]
        public void CollectData_DoesNotCallLoadData_WithoutKey()
        {
            const string path = "path";
            var consoleWrapper = Substitute.For<IConsoleWrapper>();
            consoleWrapper.ReadLine().Returns(path);

            var constants = Substitute.For<IConstants>();
            var studentDataProcessor = Substitute.For<IStudentDataProcessor>();

            var sut = new MainMenu(consoleWrapper, constants, studentDataProcessor);

            sut.CollectData();

            studentDataProcessor.Received(0).LoadData(path);
        }
    }
}

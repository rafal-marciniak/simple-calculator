using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Core;

namespace SimpleCalculator.Tests.Commands
{
    internal class PrintCommandTests
    {
        [Test]
        public void ReadsRegisterValueUsingTheProvidedKey()
        {
            _sut?.Execute();

            _registryMock?.Verify(x => x.GetRegisterValue(It.Is<string>(key => key == RegisterKey)), Times.Once);
        }

        [Test]
        public void WritesTheRegistervalueToTheConsole()
        {
            _sut?.Execute();

            _consoleProxyMock?.Verify(x => x.WriteLine(It.Is<decimal>(value => value == 150)), Times.Once);
        }

		[SetUp]
        public void Setup()
        {
            _registryMock = new Mock<IRegistry>();
            _registryMock
                .Setup(x => x.GetRegisterValue(It.Is<string>(key => key == RegisterKey)))
                .Returns(150);

            _consoleProxyMock = new Mock<IConsoleProxy>();

			_sut = new PrintCommand(_registryMock.Object, RegisterKey, _consoleProxyMock.Object, Mock.Of<ILogger>());
        }

        private Mock<IRegistry>? _registryMock;
        private Mock<IConsoleProxy>? _consoleProxyMock;
        private PrintCommand? _sut;

        private const string RegisterKey = "REG";
    }
}

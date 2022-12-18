using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;

namespace SimpleCalculator.Tests.Commands
{
	internal class ClearScreenCommandTests
	{
		[Test]
		public void CallsClearOnSystemConsole()
		{
			_sut.Execute();

			_consoleProxyMock.Verify(x => x.Clear(), Times.Once);
		}

		public ClearScreenCommandTests()
		{
			_consoleProxyMock = new Mock<IConsoleProxy>();
			_sut = new ClearScreenCommand(_consoleProxyMock.Object);
		}

		private readonly Mock<IConsoleProxy> _consoleProxyMock;
		private readonly ClearScreenCommand _sut;
	}
}

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
			var consoleProxyMock = new Mock<IConsoleProxy>();
			var sut = new ClearScreenCommand(consoleProxyMock.Object);

			sut.Execute();

			consoleProxyMock.Verify(x => x.Clear(), Times.Once);
		}
	}
}

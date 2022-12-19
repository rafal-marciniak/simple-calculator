using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;

namespace SimpleCalculator.Tests.Commands
{
	public class QuitCommandTests
	{
		[Test]
		public void StopsTheApplicationGracefullyWhenExecuted()
		{
			var hostApplicationLifetimeMock = new Mock<IHostApplicationLifetime>();

			var sut = new QuitCommand(hostApplicationLifetimeMock.Object);
			sut.Execute();

			hostApplicationLifetimeMock.Verify(x => x.StopApplication(), Times.Once);
		}
	}
}

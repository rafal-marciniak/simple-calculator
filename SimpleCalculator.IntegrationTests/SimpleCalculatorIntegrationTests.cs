using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;
using SimpleCalculator.Core;

namespace SimpleCalculator.IntegrationTests
{
	[TestFixture]
	public class SimpleCalculatorIntegrationTests
	{
		[Test]
		public void CalculateCircleAreaTest()
		{
			//arrange
			var hostApplicationLifetime = Mock.Of<IHostApplicationLifetime>();
			var console = new Mock<IConsoleProxy>();

			var commands = new[] { "Area add PI", "Area multiply R", "Area multiply R", "R add 10", "PI add 3.142", "print Area", "quit" };
			var registry = new Registry();
			var parsers = new ICommandParser[]
			{
				new RegisterOperationCommandParser(registry),
				new PrintCommandParser(registry, console.Object, Mock.Of<ILogger<PrintCommandParser>>()),
				new QuitCommandParser(hostApplicationLifetime)
			};

			var commandHandler = new CommandHandler(parsers, Mock.Of<ILogger<CommandHandler>>());

			//act
			foreach (var command in commands)
			{
				commandHandler.Handle(command);
			}

			//assert
			console.Verify(x => x.WriteLine(It.Is<decimal>(value => value == 314.2M)), Times.Once);
		}
	}
}

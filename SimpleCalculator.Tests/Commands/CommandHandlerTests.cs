using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;

namespace SimpleCalculator.Tests.Commands
{
	[TestFixture]
	public class CommandHandlerTests
	{
		[Test]
		public void TrimsAndConvertsTheCommandToLowerCase()
		{
			_sut!.Handle("  test COMMAND  ");

			_commandParser2!.Verify(x => x.Parse(It.Is<string>(c => c == "test command")), Times.Once);
		}

		[Test]
		public void OnlyCallsParseOnParsersThatCanParseTheCommand()
		{
			_sut!.Handle("say parse one more time");

			_commandParser1!.Verify(x => x.Parse(It.IsAny<string>()), Times.Never);
			_commandParser2!.Verify(x => x.Parse(It.IsAny<string>()), Times.Once);
		}

		[Test]
		public void CallsExecuteOnTheCommandReturnedByMatchingParser()
		{
			var commandMock = new Mock<ICommand>();	

			_commandParser2!
				.Setup(x => x.Parse(It.IsAny<string>()))
				.Returns(commandMock.Object);

			_sut!.Handle("test command");

			commandMock.Verify(x => x.Execute(), Times.Once);
		}

		[SetUp]
		public void Setup()
		{
			_commandParser1 = new Mock<ICommandParser>();
			_commandParser1
				.Setup(x => x.CanParse(It.IsAny<string>()))
				.Returns(false);

			_commandParser2 = new Mock<ICommandParser>();
			_commandParser2
				.Setup(x => x.CanParse(It.IsAny<string>()))
				.Returns(true);

			var commandParsers = new[] { _commandParser1.Object, _commandParser2.Object };

			_sut = new CommandHandler(commandParsers, Mock.Of<ILogger<CommandHandler>>());
		}

		private CommandHandler? _sut;
		private Mock<ICommandParser>? _commandParser1;
		private Mock<ICommandParser>? _commandParser2;
	}
}

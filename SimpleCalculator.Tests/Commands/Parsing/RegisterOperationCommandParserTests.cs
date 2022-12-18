using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;
using SimpleCalculator.Core;

namespace SimpleCalculator.Tests.Commands.Parsing
{
	internal class RegisterOperationCommandParserTests
	{
		[TestFixture]
		public class CanParse : RegisterOperationCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void CannotParseEmptyCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[TestCaseSource(nameof(InvalidCommandCases))]
			public void CannotParseNonmatchingCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[TestCaseSource(nameof(ValidCommandCases))]
			public void CanParseAddSubtractAndMultiplyCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class Parse : RegisterOperationCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void ReturnsNullForEmptyCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[TestCaseSource(nameof(InvalidCommandCases))]
			public void ReturnsNullForNonmatchingCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[TestCaseSource(nameof(ValidCommandCases))]
			public void ReturnsRegisterOperationCommandForAddSubtractAndMultiplyCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<RegisterOperationCommand>());
			}
		}

		public RegisterOperationCommandParserTests()
		{
			Sut = new RegisterOperationCommandParser(Mock.Of<IRegistry>());
		}

		protected static string[] ValidCommandCases =
		{
			"x add y",
			"x subtract y",
			"x multiply y",
			"x add 150",
			"x subtract 1",
			"x multiply 11",
			"x add 7.5",
			"x subtract 11.7",
			"x multiply 3.1415"
		};

		protected static string[] InvalidCommandCases =
		{
			"cls",
			"quit",
			"print x",
			"x add",
			"x multiply   ",
			"subtract y",
			"x add y.z",
			"x multiply 12..23"
		};

		protected readonly RegisterOperationCommandParser Sut;
	}
}

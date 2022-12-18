using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;
using SimpleCalculator.Core;

namespace SimpleCalculator.Tests.Commands.Parsing
{
	internal class PrintCommandParserTests
	{
		[TestFixture]
		public class CanParseTests : PrintCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void CannotParseEmptyCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[TestCase("cls")]
			[TestCase("help")]
			[TestCase("print")]
			[TestCase("x add y")]
			public void CannotParseNonmatchingCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[Test]
			public void CanParseTheCommandPrint()
			{
				var result = Sut.CanParse("print x");

				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class ParseTests : PrintCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void ReturnsNullForEmptyCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[TestCase("cls")]
			[TestCase("help")]
			[TestCase("print")]
			[TestCase("x add y")]
			public void ReturnsNullForNonmatchingCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[Test]
			public void ReturnsPrintCommandForTheComandPrint()
			{
				var result = Sut.Parse("print x");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<PrintCommand>());
			}
		}

		public PrintCommandParserTests()
		{
			Sut = new PrintCommandParser(Mock.Of<IRegistry>(), Mock.Of<ILogger<PrintCommandParser>>());
		}

		protected readonly PrintCommandParser Sut;
	}
}

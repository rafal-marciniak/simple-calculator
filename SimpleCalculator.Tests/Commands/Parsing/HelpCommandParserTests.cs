using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;

namespace SimpleCalculator.Tests.Commands.Parsing
{
	internal class HelpCommandParserTests
	{
		[TestFixture]
		public class CanParse : HelpCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void CannotParseEmptyCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[TestCase("cls")]
			[TestCase("print x")]
			[TestCase("x add y")]
			public void CannotParseNonmatchingCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[Test]
			public void CanParseTheCommandHelp()
			{
				var result = Sut.CanParse("help");

				Assert.That(result, Is.True);
			}

			[Test]
			public void IsCaseInsensitive()
			{
				var result = Sut.CanParse("HElp");

				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class Parse : HelpCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void ReturnsNullForEmptyCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[TestCase("cls")]
			[TestCase("print x")]
			[TestCase("x add y")]
			public void ReturnsNullForNonmatchingCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[Test]
			public void ReturnsHelpCommandForTheComandHelp()
			{
				var result = Sut.Parse("help");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<HelpCommand>());
			}

			[Test]
			public void IsCaseInsensitive()
			{
				var result = Sut.Parse("HElp");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<HelpCommand>());
			}
		}

		public HelpCommandParserTests()
		{
			Sut = new HelpCommandParser(Mock.Of<IConsoleProxy>());
		}

		protected readonly HelpCommandParser Sut;
	}
}

using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;

namespace SimpleCalculator.Tests.Commands.Parsing
{
	internal class QuitCommandParserTests
	{
		[TestFixture]
		public class CanParseTests : QuitCommandParserTests
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
			public void CanParseTheCommandQuit()
			{
				var result = Sut.CanParse("quit");

				Assert.That(result, Is.True);
			}

			[Test]
			public void IsCaseInsensitive()
			{
				var result = Sut.CanParse("QUIT");

				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class ParseTests : QuitCommandParserTests
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
			public void ReturnsQuitCommandForTheComandQuit()
			{
				var result = Sut.Parse("quit");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<QuitCommand>());
			}

			[Test]
			public void IsCaseInsensitive()
			{
				var result = Sut.Parse("QUIT");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<QuitCommand>());
			}
		}

		public QuitCommandParserTests()
		{
			Sut = new QuitCommandParser(Mock.Of<IHostApplicationLifetime>());
		}

		protected readonly QuitCommandParser Sut;
	}
}

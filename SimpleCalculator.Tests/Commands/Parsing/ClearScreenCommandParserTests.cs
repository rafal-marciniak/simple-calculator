using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;

namespace SimpleCalculator.Tests.Commands.Parsing
{
	internal class ClearScreenCommandParserTests
	{
		[TestFixture]
		public class CanParse : ClearScreenCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void CannotParseEmptyCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[TestCase("quit")]
			[TestCase("print x")]
			[TestCase("x add y")]
			public void CannotParseNonmatchingCommands(string command)
			{
				var result = Sut.CanParse(command);

				Assert.That(result, Is.False);
			}

			[Test]
			public void CanParseTheCommandCls()
			{
				var result = Sut.CanParse("cls");

				Assert.That(result, Is.True);
			}

			[Test]
			public void IsCaseInsensitive()
			{
				var result = Sut.CanParse("cLs");

				Assert.That(result, Is.True);
			}
		}

		[TestFixture]
		public class Parse : ClearScreenCommandParserTests
		{
			[TestCaseSource(typeof(EmptyValueTestSource))]
			public void ReturnsNullForEmptyCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[TestCase("quit")]
			[TestCase("print x")]
			[TestCase("x add y")]
			public void ReturnsNullForNonmatchingCommands(string command)
			{
				var result = Sut.Parse(command);

				Assert.That(result, Is.Null);
			}

			[Test]
			public void ReturnsClearScreenCommandForTheComandCls()
			{
				var result = Sut.Parse("cls");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<ClearScreenCommand>());
			}

			[Test]
			public void IsCaseInsensitive()
			{
				var result = Sut.Parse("cLs");

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.TypeOf<ClearScreenCommand>());
			}
		}

		public ClearScreenCommandParserTests()
		{
			Sut = new ClearScreenCommandParser(Mock.Of<IConsoleProxy>());
		}

		protected readonly ClearScreenCommandParser Sut;
	}
}

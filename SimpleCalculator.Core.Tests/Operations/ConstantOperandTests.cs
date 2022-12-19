using NUnit.Framework;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core.Tests.Operations
{
	[TestFixture]
	public class ConstantOperandTests
	{
		[Test]
		public void ReturnsValueProvidedAtCreation()
		{
			var sut = new ConstantOperand(42);

			Assert.That(sut.Value, Is.EqualTo(42));
		}
	}
}

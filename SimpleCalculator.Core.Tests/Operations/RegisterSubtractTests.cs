using Moq;
using NUnit.Framework;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core.Tests.Operations
{
	[TestFixture]
	public class RegisterSubtractTests
	{
		[Test]
		public void DecreasesProvidedRegisterValueByTheOperandValue()
		{
			var register = new Register("x") { Value = 50 };
			var operand = new Mock<IOperand>();
			operand.SetupGet(x => x.Value).Returns(150);
			var sut = new RegisterSubtract(operand.Object);

			sut.Apply(register);

			Assert.That(register.Value, Is.EqualTo(-100));
		}
	}
}

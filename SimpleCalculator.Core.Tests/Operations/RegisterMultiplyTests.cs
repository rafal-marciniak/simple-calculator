using Moq;
using NUnit.Framework;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core.Tests.Operations
{
	[TestFixture]
	public class RegisterMultiplyTests
	{
		[Test]
		public void MultipliesProvidedRegisterValueByTheOperandValue()
		{
			var register = new Register("x") { Value = 50 };
			var operand = new Mock<IOperand>();
			operand.SetupGet(x => x.Value).Returns(3.5M);
			var sut = new RegisterMultiply(operand.Object);

			sut.Apply(register);

			Assert.That(register.Value, Is.EqualTo(175));
		}
	}
}

using Moq;
using NUnit.Framework;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core.Tests.Operations
{
	[TestFixture]
	public class RegisterOperandTests
	{
		[Test]
		public void ReadsValueFromTheRegistryForAGivenKeyAndReturnsIt()
		{
			var registryMock = new Mock<IRegistry>();
			registryMock
				.Setup(x => x.GetRegisterValue(It.IsAny<string>()))
				.Returns(33);
			var sut = new RegisterOperand(registryMock.Object, "x");

			Assert.That(sut.Value, Is.EqualTo(33));
			registryMock.Verify(x => x.GetRegisterValue(It.Is<string>(key => key == "x")), Times.Once);
		}
	}
}

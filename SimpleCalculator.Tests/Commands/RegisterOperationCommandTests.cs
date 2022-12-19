using Moq;
using NUnit.Framework;
using SimpleCalculator.Commands;
using SimpleCalculator.Core;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Tests.Commands
{
	internal class RegisterOperationCommandTests
	{
		[TestCase("add", typeof(RegisterAdd))]
		[TestCase("subtract", typeof(RegisterSubtract))]
		[TestCase("multiply", typeof(RegisterMultiply))]
		public void CreatesSpecificRegisterOperationForGivenOperationType(string operationType, Type expectedRegisterOperationType)
		{
			var registryMock = new Mock<IRegistry>();
			var _sut = new RegisterOperationCommand(registryMock.Object, RegisterKey, operationType, 100);

			_sut.Execute();

			registryMock.Verify(x => x.AppendRegisterChange(
					It.Is<string>(key => key == RegisterKey),
					It.Is<IRegisterOperation>(op => op.GetType().Equals(expectedRegisterOperationType))),
				Times.Once);
		}

		[Test]
		public void ThrowsArgumentExceptionWhenOperationTypeIsUnknown()
		{
			Assert.Throws<ArgumentException>(() => new RegisterOperationCommand(Mock.Of<IRegistry>(), RegisterKey, "unknown", 100));
		}

		private const string RegisterKey = "REG";
	}
}

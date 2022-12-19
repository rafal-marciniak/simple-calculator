using Moq;
using NUnit.Framework;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core.Tests
{
	public class RegistryTests
	{
		[TestFixture]
		public class GetRegisterValue
		{
			[Test]
			public void ThrowsArgumentExceptionWhenNonExistingRegisterWasRequested()
			{
				var sut = new Registry();

				Assert.Throws<ArgumentException>(() => sut.GetRegisterValue("x"));
			}

			[Test]
			public void AppliesAllPendingChangesBeforeResolvingRegisterValue()
			{
				var sut = new Registry();
				sut.AppendRegisterChange("x", _add200.Object);
				sut.AppendRegisterChange("x", _multiply3.Object);

				var result = sut.GetRegisterValue("x");

				Assert.That(result, Is.EqualTo(600));
			}

			[Test]
			public void MultipleCallsOnlyApplyEachChangeOnce()
			{
				var sut = new Registry();
				sut.AppendRegisterChange("x", _add200.Object);
				sut.GetRegisterValue("x");
				sut.GetRegisterValue("x");

				var result = sut.GetRegisterValue("x");

				Assert.That(result, Is.EqualTo(200));
			}

			[SetUp]
			public void Setup()
			{
				_add200 = new Mock<IRegisterOperation>();
				_add200
					.Setup(x => x.Apply(It.IsAny<Register>()))
					.Callback((Register register) => register.Value += 200);

				_multiply3 = new Mock<IRegisterOperation>();
				_multiply3
					.Setup(x => x.Apply(It.IsAny<Register>()))
					.Callback((Register register) => register.Value *= 3);
			}

			private Mock<IRegisterOperation> _add200;
			private Mock<IRegisterOperation> _multiply3;
		}

		[TestFixture]
		public class AppendRegisterChange
		{
			[Test]
			public void CreatesRegisterIfDoesntExist()
			{
				var sut = new Registry();

				sut.AppendRegisterChange("x", Mock.Of<IRegisterOperation>());

				Assert.DoesNotThrow(() => sut.GetRegisterValue("x"));
			}
		}
	}
}

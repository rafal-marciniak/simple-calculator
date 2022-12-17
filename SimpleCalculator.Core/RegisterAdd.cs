namespace SimpleCalculator.Core
{
	public class RegisterAdd : IRegisterChange
	{
		public void Apply()
		{
			_registerSimpleChange.Apply();
		}

		public RegisterAdd(IRegistry registry, string registerKey, IOperand operand)
		{
			_registerSimpleChange = new RegisterSimpleChange(registry, registerKey, operand,
				(currentValue, operandValue) => currentValue + operandValue);
		}

		private readonly IRegisterChange _registerSimpleChange;
	}
}

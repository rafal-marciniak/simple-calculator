namespace SimpleCalculator.Core
{
	internal class RegisterSimpleChange : IRegisterChange
	{
		public void Apply()
		{
			var currentValue = _registry.GetRegisterValue(_registerKey);
			var newValue = _registerChangeFunction(currentValue, _operand.Value);
			_registry.SetRegisterValue(_registerKey, newValue);
		}

		internal RegisterSimpleChange(IRegistry registry, string registerKey, IOperand operand, Func<decimal, decimal, decimal> registerChangeFunction)
		{
			_registry = registry;
			_registerKey = registerKey;
			_operand = operand;
			_registerChangeFunction = registerChangeFunction;
		}

		private readonly IRegistry _registry;
		private readonly string _registerKey;
		private readonly IOperand _operand;
		private readonly Func<decimal, decimal, decimal> _registerChangeFunction;
	}
}

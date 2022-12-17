namespace SimpleCalculator.Core
{
	public class RegisterOperand : IOperand
	{
		public decimal Value => _registry.CalculateRegisterValue(_registerKey);

		public RegisterOperand(IRegistry registry, string registerKey)
		{
			_registry = registry;
			_registerKey = registerKey;
		}

		private readonly IRegistry _registry;
		private readonly string _registerKey;
	}
}

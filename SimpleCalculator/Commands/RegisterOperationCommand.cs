using SimpleCalculator.Core;

namespace SimpleCalculator.Commands
{
	public class RegisterOperationCommand : ICommand
	{
		public void Execute()
		{
			IOperand operand = _registerToTakeValueFrom != null
					? new RegisterOperand(_registry, _registerToTakeValueFrom)
					: new ConstantOperand(_value.GetValueOrDefault(0));

			IRegisterChange registerChange = _operationType switch
			{
				RegisterOperationType.Add => new RegisterAdd(_registry, _registerKey, operand),
				RegisterOperationType.Subtract => new RegisterSubtract(_registry, _registerKey, operand),
				RegisterOperationType.Multiply => new RegisterMultiply(_registry, _registerKey, operand),
				_ => throw new Exception(), //todo: create a custom exception for this
			};

			_registry.AppendRegisterChange(_registerKey, registerChange);
		}

		public RegisterOperationCommand(IRegistry registry, string registerKey, string operationType, decimal value)
			: this(registry, registerKey, operationType)
		{
			_value = value;
		}

		public RegisterOperationCommand(IRegistry registry, string registerKey, string operationType, string registerToTakeValueFrom)
			: this(registry, registerKey, operationType)
		{
			_registerToTakeValueFrom = registerToTakeValueFrom;
		}

		private RegisterOperationCommand(IRegistry registry, string registerKey, string operationType)
		{
			_registry = registry;
			_registerKey = registerKey;
			_operationType = (RegisterOperationType)Enum.Parse(typeof(RegisterOperationType), operationType, true);
		}

		private readonly IRegistry _registry;
		private readonly string _registerKey;
		private readonly RegisterOperationType _operationType;
		private readonly decimal? _value;
		private readonly string? _registerToTakeValueFrom;
	}
}

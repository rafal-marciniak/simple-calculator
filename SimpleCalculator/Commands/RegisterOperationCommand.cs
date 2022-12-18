using SimpleCalculator.Core;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Commands
{
    public class RegisterOperationCommand : ICommand
	{
		public void Execute()
		{
			IOperand operand = _registerToTakeValueFrom != null
					? new RegisterOperand(_registry, _registerToTakeValueFrom)
					: new ConstantOperand(_value.GetValueOrDefault(0));

			IRegisterOperation operation = _operationType switch
			{
				RegisterOperationType.Add => new RegisterAdd(operand),
				RegisterOperationType.Subtract => new RegisterSubtract(operand),
				RegisterOperationType.Multiply => new RegisterMultiply(operand),
				_ => throw new Exception("Unsupported operation type."),
			};

			_registry.AppendRegisterChange(_registerKey, operation);
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

using SimpleCalculator.Core.Extensions;
using SimpleCalculator.Core.Operations;

namespace SimpleCalculator.Core
{
    public class Registry : IRegistry
	{
		public decimal GetRegisterValue(string registerKey)
		{
			if (!_registers.ContainsKey(registerKey))
			{
				throw new ArgumentException($"Register {registerKey} not found.");
			}

			ApplyPendingChangesIfNecessary(registerKey);

			return _registers[registerKey].Value;
		}

		public void AppendRegisterChange(string registerKey, IRegisterOperation operation)
		{
			if (!_registers.ContainsKey(registerKey))
			{
				_registers.Add(registerKey, new Register(registerKey));
			}

			var list = _pendingChanges.GetOrAdd(registerKey, new Queue<IRegisterOperation>());
			list.Enqueue(operation);
		}

		private void ApplyPendingChangesIfNecessary(string registerKey)
		{
			if (_pendingChanges.TryGetValue(registerKey, out var changesQueue))
			{
				while (changesQueue.Any())
				{
					var change = changesQueue.Dequeue();
					var register = _registers[registerKey];
					change.Apply(register);
				}
			}
		}

		private readonly Dictionary<string, Register> _registers = new();
		private readonly Dictionary<string, Queue<IRegisterOperation>> _pendingChanges = new();
	}
}

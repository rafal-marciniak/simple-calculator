using SimpleCalculator.Core.Extensions;

namespace SimpleCalculator.Core
{
	public class Registry : IRegistry
	{
		public decimal CalculateRegisterValue(string registerKey)
		{
			if (!_registers.ContainsKey(registerKey))
			{
				throw new ArgumentException($"Register {registerKey} not found.");
			}

			ApplyPendingChangesIfNecessary(registerKey);

			return _registers[registerKey].Value;
		}

		//todo move it somewhere internal
		public decimal GetRegisterValue(string registerKey)
		{
			var register = _registers.GetOrAdd(registerKey, new Register(registerKey));

			return register.Value;
		}

		//todo move it somewhere internal
		public decimal SetRegisterValue(string registerKey, decimal value)
		{
			var register = _registers.GetOrAdd(registerKey, new Register(registerKey));

			return register.Value = value;
		}

		public void AppendRegisterChange(string registerKey, IRegisterChange registerChange)
		{
			if (!_registers.ContainsKey(registerKey))
			{
				_registers.Add(registerKey, new Register(registerKey));
			}

			var list = _pendingChanges.GetOrAdd(registerKey, new Queue<IRegisterChange>());
			list.Enqueue(registerChange);
		}

		private void ApplyPendingChangesIfNecessary(string registerKey)
		{
			if (_pendingChanges.TryGetValue(registerKey, out var changesQueue))
			{
				while (changesQueue.Any())
				{
					var change = changesQueue.Dequeue();
					change.Apply();
				}
			}
		}

		private readonly Dictionary<string, Register> _registers = new();
		private readonly Dictionary<string, Queue<IRegisterChange>> _pendingChanges = new();
	}
}

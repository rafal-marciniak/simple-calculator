using Microsoft.Extensions.Logging;
using SimpleCalculator.Core;

namespace SimpleCalculator.Commands
{
	internal class PrintCommand : ICommand
	{
		public void Execute()
		{
			try
			{
				var registerValue = _registry.CalculateRegisterValue(_registerKey);
				Console.WriteLine(registerValue);
			}
			catch (ArgumentException e)
			{
				_logger.LogError("An error occured when trying to print: {errorMessage}", e.Message);
			}
		}

		public PrintCommand(IRegistry registry, string registerKey, ILogger logger)
		{
			_registry = registry;
			_registerKey = registerKey;
			_logger = logger;
		}

		private readonly IRegistry _registry;
		private readonly string _registerKey;
		private readonly ILogger _logger;
	}
}

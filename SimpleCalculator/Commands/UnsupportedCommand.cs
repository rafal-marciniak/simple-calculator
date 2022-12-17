using Microsoft.Extensions.Logging;

namespace SimpleCalculator.Commands
{
	public class UnsupportedCommand : ICommand
	{
		public void Execute()
		{
			_logger.LogWarning("The command '{command}' is not supported.", _command);
		}

		public UnsupportedCommand(string command, ILogger logger)
		{
			_command = command;
			_logger = logger;
		}

		private readonly string _command;
		private readonly ILogger _logger;
	}
}

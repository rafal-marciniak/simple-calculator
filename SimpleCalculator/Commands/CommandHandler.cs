using Microsoft.Extensions.Logging;
using SimpleCalculator.Commands.Parsing;

namespace SimpleCalculator.Commands
{
	internal class CommandHandler : ICommandHandler
    {
		public void Handle(string command)
        {
			command = command
				.ToLower()
				.Trim();
			
			var parser = _commandParsers.FirstOrDefault(x => x.CanParse(command));
			var executableCommand = parser?.Parse(command) ?? new UnsupportedCommand(command, _logger);
			
			executableCommand?.Execute();
		}

        public CommandHandler(IEnumerable<ICommandParser> commandParsers, ILogger<CommandHandler> logger)
        {
			_commandParsers = commandParsers;
			_logger = logger;
		}

		private readonly IEnumerable<ICommandParser> _commandParsers;
		private readonly ILogger<CommandHandler> _logger;
	}
}

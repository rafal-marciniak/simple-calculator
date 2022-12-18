using Microsoft.Extensions.Logging;
using SimpleCalculator.Core;
using System.Text.RegularExpressions;

namespace SimpleCalculator.Commands.Parsing
{
	internal partial class PrintCommandParser : ICommandParser
	{
		public bool CanParse(string command) => command != null && CommandRegex().IsMatch(command);

		public ICommand? Parse(string command)
		{
			if (CanParse(command))
			{
				var match = CommandRegex().Match(command);
				var registerKey = match.Groups[1].Value;

				return new PrintCommand(_registry, registerKey, _console, _logger);
			}

			return null;
		}

		public PrintCommandParser(IRegistry registry, IConsoleProxy console, ILogger<PrintCommandParser> logger)
		{
			_registry = registry;
			_console = console;
			_logger = logger;
		}

		private readonly IRegistry _registry;
		private readonly IConsoleProxy _console;
		private readonly ILogger<PrintCommandParser> _logger;

		[GeneratedRegex("^print\\s+(\\w+)$")]
		private static partial Regex CommandRegex();
	}
}

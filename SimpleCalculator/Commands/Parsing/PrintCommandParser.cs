using Microsoft.Extensions.Logging;
using SimpleCalculator.Core;
using System.Text.RegularExpressions;

namespace SimpleCalculator.Commands.Parsing
{
	internal partial class PrintCommandParser : ICommandParser
	{
		public bool CanParse(string command) => CommandRegex().IsMatch(command);

		public ICommand? Parse(string command)
		{
			var match = CommandRegex().Match(command);
			var registerKey = match.Groups[1].Value;

			return new PrintCommand(_registry, registerKey, _logger);
		}

		public PrintCommandParser(IRegistry registry, ILogger<PrintCommandParser> logger)
		{
			_registry = registry;
			_logger = logger;
		}

		private readonly IRegistry _registry;
		private readonly ILogger<PrintCommandParser> _logger;

		[GeneratedRegex("^print\\s+(\\w+)$")]
		private static partial Regex CommandRegex();
	}
}

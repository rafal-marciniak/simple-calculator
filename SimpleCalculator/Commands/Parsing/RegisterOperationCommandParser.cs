using SimpleCalculator.Core;
using System.Text.RegularExpressions;

namespace SimpleCalculator.Commands.Parsing
{
	internal partial class RegisterOperationCommandParser : ICommandParser
	{
		public bool CanParse(string command) => CommandRegex().IsMatch(command);

		public ICommand? Parse(string command)
		{
			var match = CommandRegex().Match(command);
			var registerKey = match.Groups[1].Value;
			var operation = match.Groups[2].Value;
			var operand = match.Groups[3].Value;

			if (decimal.TryParse(operand, out var value))
			{
				return new RegisterOperationCommand(_registry, registerKey, operation, value);
			}

			return new RegisterOperationCommand(_registry, registerKey, operation, operand);
		}

		public RegisterOperationCommandParser(IRegistry registry)
		{
			_registry = registry;
		}

		private readonly IRegistry _registry;

		[GeneratedRegex("^(\\w+)\\s+(add|subtract|multiply)\\s+(\\w+)$")]
		private static partial Regex CommandRegex();
	}
}

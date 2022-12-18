namespace SimpleCalculator.Commands.Parsing
{
	internal class HelpCommandParser : ICommandParser
	{
		public bool CanParse(string command) => string.Equals(command, HelpCommandName, StringComparison.InvariantCultureIgnoreCase);

		public ICommand? Parse(string command)
		{
			if (CanParse(command))
			{
				return new HelpCommand(_console);
			}

			return null;
		}

		public HelpCommandParser(IConsoleProxy console)
		{
			_console = console;
		}

		private readonly IConsoleProxy _console;
		private const string HelpCommandName = "help";
	}
}

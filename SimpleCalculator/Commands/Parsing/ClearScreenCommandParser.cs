namespace SimpleCalculator.Commands.Parsing
{
	internal class ClearScreenCommandParser : ICommandParser
	{
		public bool CanParse(string command) => string.Equals(command, ClearScreenCommandName, StringComparison.InvariantCultureIgnoreCase);

		public ICommand? Parse(string command)
		{
			if (CanParse(command))
			{
				return new ClearScreenCommand(_console);
			}

			return null;
		}

		public ClearScreenCommandParser(IConsoleProxy console)
		{
			_console = console;
		}

		private readonly IConsoleProxy _console;
		private const string ClearScreenCommandName = "cls";
	}
}

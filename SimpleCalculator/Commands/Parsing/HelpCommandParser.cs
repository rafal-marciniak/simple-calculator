namespace SimpleCalculator.Commands.Parsing
{
	internal class HelpCommandParser : ICommandParser
	{
		public bool CanParse(string command) => string.Equals(command, HelpCommandName, StringComparison.InvariantCultureIgnoreCase);

		public ICommand? Parse(string command)
		{
			if (CanParse(command))
			{
				return new HelpCommand();
			}

			return null;
		}

		private const string HelpCommandName = "help";
	}
}

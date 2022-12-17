using SimpleCalculator.Core.Commands;

namespace SimpleCalculator.Commands.Parsing
{
	internal class ClearScreenCommandParser : ICommandParser
	{
		public bool CanParse(string command) => command.Equals(ClearScreenCommandName, StringComparison.InvariantCultureIgnoreCase);

		public ICommand? Parse(string command)
		{
			if (CanParse(command))
			{
				return new ClearScreenCommand();
			}

			return null;
		}

		private const string ClearScreenCommandName = "cls";
	}
}

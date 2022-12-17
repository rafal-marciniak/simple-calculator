using SimpleCalculator.Core.Commands;

namespace SimpleCalculator.Commands.Parsing
{
    internal interface ICommandParser
	{
		bool CanParse(string command);
		ICommand? Parse(string command);
	}
}

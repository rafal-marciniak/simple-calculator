using SimpleCalculator.Core.Commands;

namespace SimpleCalculator.Commands.Parsing
{
    internal class QuitCommandParser : ICommandParser
    {
        public bool CanParse(string command) => command.Equals(QuitCommandName, StringComparison.InvariantCultureIgnoreCase);

        public ICommand? Parse(string command)
        {
            if (CanParse(command))
            {
                return new QuitCommand();
            }

            return null;
        }

        private const string QuitCommandName = "quit";
    }
}

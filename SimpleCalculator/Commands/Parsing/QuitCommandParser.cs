using Microsoft.Extensions.Hosting;

namespace SimpleCalculator.Commands.Parsing
{
	internal class QuitCommandParser : ICommandParser
    {
        public bool CanParse(string command) => string.Equals(command, QuitCommandName, StringComparison.InvariantCultureIgnoreCase);

        public ICommand? Parse(string command)
        {
            if (CanParse(command))
            {
                return new QuitCommand(_applicationLifetime);
            }

            return null;
        }

		public QuitCommandParser(IHostApplicationLifetime applicationLifetime)
		{
			_applicationLifetime = applicationLifetime;
		}

		private readonly IHostApplicationLifetime _applicationLifetime;
		private const string QuitCommandName = "quit";
    }
}

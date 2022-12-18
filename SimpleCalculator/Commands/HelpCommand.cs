using System.Text;

namespace SimpleCalculator.Commands
{
	internal class HelpCommand : ICommand
	{
		public void Execute()
		{
			//TODO: read a help file?
			var sb = new StringBuilder();
			
			sb.AppendLine("<register> <operation> <value>|<register>");
			sb.AppendLine("Executes and operation on a specified register. You can provide a constant value (decimals accept a single dot) or a name of another register.");
			sb.AppendLine("Currently supported operations: add|subtract|multiply.");
			sb.AppendLine("Examples:");
			sb.AppendLine("\tsalaries add 20");
			sb.AppendLine("\tsalaries multiply 3.5");
			sb.AppendLine("\trevenue subtract costs");

			sb.AppendLine();
			sb.AppendLine("print <register>");
			sb.AppendLine("Prints register value.");
			sb.AppendLine("Examples:");
			sb.AppendLine("\tprint revenue");

			sb.AppendLine();
			sb.AppendLine("quit");
			sb.AppendLine("Exits the application.");

			sb.AppendLine();
			sb.AppendLine("cls");
			sb.AppendLine("Clears the screen.");

			sb.AppendLine();
			sb.AppendLine("help");
			sb.AppendLine("Displays commands overview. You are here.");

			_console.WriteLine(sb.ToString());
		}

		public HelpCommand(IConsoleProxy console)
		{
			_console = console;
		}

		private readonly IConsoleProxy _console;
	}
}

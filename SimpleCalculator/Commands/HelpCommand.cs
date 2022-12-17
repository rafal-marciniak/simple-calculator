using System.Text;

namespace SimpleCalculator.Commands
{
	internal class HelpCommand : ICommand
	{
		//TODO: read a help file?
		public void Execute()
		{
			var sb = new StringBuilder();
			
			sb.AppendLine("<register> <operation> <value>|<register>");
			sb.AppendLine("Executes and operation on a specified register. You can provide a constant value or a name of another register.");
			sb.AppendLine("Currently supported operations: add|subtract|multiply.");

			sb.AppendLine();
			sb.AppendLine("print <register>");
			sb.AppendLine("Prints register value.");

			sb.AppendLine();
			sb.AppendLine("quit");
			sb.AppendLine("Exits the application.");

			sb.AppendLine();
			sb.AppendLine("cls");
			sb.AppendLine("Clears the screen.");

			sb.AppendLine();
			sb.AppendLine("help");
			sb.AppendLine("Displays commands overview. You are here.");

			Console.WriteLine(sb.ToString());
		}
	}
}

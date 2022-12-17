using SimpleCalculator.Core.Commands;

namespace SimpleCalculator.Commands
{
	internal class ClearScreenCommand : ICommand
	{
		public void Execute()
		{
			Console.Clear();
		}
	}
}

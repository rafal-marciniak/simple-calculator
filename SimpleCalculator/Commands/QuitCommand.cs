namespace SimpleCalculator.Commands
{
	internal class QuitCommand : ICommand
	{
		public void Execute()
		{
			Environment.Exit(0);
		}
	}
}

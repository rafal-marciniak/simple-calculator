namespace SimpleCalculator.Commands
{
	internal class ClearScreenCommand : ICommand
	{
		public void Execute()
		{
			_console.Clear();
		}

		public ClearScreenCommand(IConsoleProxy console)
		{
			_console = console;
		}

		private readonly IConsoleProxy _console;
	}
}

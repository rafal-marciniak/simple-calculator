using Microsoft.Extensions.Hosting;

namespace SimpleCalculator.Commands
{
	internal class QuitCommand : ICommand
	{
		public void Execute()
		{
			_applicationLifetime.StopApplication();
		}

		public QuitCommand(IHostApplicationLifetime applicationLifetime)
		{
			_applicationLifetime = applicationLifetime;
		}

		private readonly IHostApplicationLifetime _applicationLifetime;
	}
}

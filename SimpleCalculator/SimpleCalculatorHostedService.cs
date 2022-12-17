using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Commands;

namespace SimpleCalculator
{
	internal class SimpleCalculatorHostedService : IHostedService
	{
		public Task StartAsync(CancellationToken cancellationToken)
		{
			_applicationLifetime.ApplicationStarted.Register(() =>
			{
				Task.Run(async () =>
				{
					try
					{
						if (_args.Args.Any())
						{
							var filePath = _args.Args.First();
							await RunFileMode(filePath);
						}
						else
						{
							RunInteractiveMode();
						}
					}
					catch (Exception ex)
					{
						_logger.LogError("An error occured: {errorMessage}", ex.Message);
					}
					finally
					{
						_applicationLifetime.StopApplication();
					}
				});
			});

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		private void RunInteractiveMode()
		{
			Console.WriteLine("Type 'help' for commands overview.");
			Console.WriteLine("Please provide a command:");

			while (true)
			{
				var line = Console.ReadLine();

				if (string.IsNullOrEmpty(line))
				{
					continue;
				}

				_commandHandler.Handle(line);
			}
		}

		private async Task RunFileMode(string filePath)
		{
			if (File.Exists(filePath))
			{
				Console.WriteLine($"Reading {filePath}.");
				Console.WriteLine();

				var commands = (await File.ReadAllLinesAsync(filePath))
					.Where(line => !string.IsNullOrWhiteSpace(line));

				foreach (var command in commands)
				{
					Console.WriteLine(command);
				}

				Console.WriteLine();

				foreach (var command in commands)
				{
					_commandHandler.Handle(command);
				}
			}
			else
			{
				_logger.LogError("File {filePath} does not exist.", filePath);
			}
		}

		public SimpleCalculatorHostedService(ISimpleCalculatorArgs args, IHostApplicationLifetime applicationLifetime, ICommandHandler commandHandler, ILogger<SimpleCalculatorHostedService> logger)
		{
			_args = args;
			_applicationLifetime = applicationLifetime;
			_commandHandler = commandHandler;
			_logger = logger;
		}

		private readonly ISimpleCalculatorArgs _args;
		private readonly IHostApplicationLifetime _applicationLifetime;
		private readonly ICommandHandler _commandHandler;
		private readonly ILogger<SimpleCalculatorHostedService> _logger;
	}
}

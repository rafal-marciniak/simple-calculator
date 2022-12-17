using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Commands;
using SimpleCalculator.Commands.Parsing;
using SimpleCalculator.Core;

namespace SimpleCalculator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IHost host = CreateHostBuilder();
			using var serviceScope = host.Services.CreateScope();

			var commandHandler = serviceScope.ServiceProvider.GetRequiredService<ICommandHandler>();

			if (args.Any())
			{
				//todo: add file support
			}
			else
			{
				DisplayWelcomeMessage();

				while (true)
				{
					var line = Console.ReadLine();

					if (string.IsNullOrEmpty(line))
					{
						continue;
					}

					commandHandler.Handle(line);
				}
			}
		}

		private static IHost CreateHostBuilder()
		{
			return Host.CreateDefaultBuilder()
				.ConfigureServices(services =>
				{
					services.AddTransient<ICommandParser, QuitCommandParser>();
					services.AddTransient<ICommandParser, RegisterOperationCommandParser>();
					services.AddTransient<ICommandParser, PrintCommandParser>();
					services.AddTransient<ICommandParser, ClearScreenCommandParser>();
					services.AddTransient<ICommandParser, HelpCommandParser>();

					services.AddScoped<ICommandHandler, CommandHandler>();
					
					services.AddSingleton<IRegistry, Registry>();
				})
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
					logging.AddSimpleConsole(options =>
					{
						options.IncludeScopes = true;
						options.SingleLine = true;
					});
				})
				.Build();
		}

		private static void DisplayWelcomeMessage()
		{
			Console.WriteLine("Type 'help' for commands overview.");
			Console.WriteLine("Please provide a command:");
		}
	}
}
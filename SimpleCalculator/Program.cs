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
		static async Task Main(string[] args)
		{
			await Host
				.CreateDefaultBuilder(args)
				.ConfigureServices(services =>
				{
					services.AddHostedService<SimpleCalculatorHostedService>();
					services.AddSingleton<ISimpleCalculatorArgs>(new SimpleCalculatorArgs(args));				

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
					logging
						.ClearProviders()
						.AddSimpleConsole(options =>
						{
							options.IncludeScopes = true;
							options.SingleLine = true;
						})
						.SetMinimumLevel(LogLevel.Warning);
				})
				.RunConsoleAsync();
		}
	}
}
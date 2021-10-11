using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace AppImporter
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();
			BuildConfiguration(builder);

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Build())
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.CreateLogger();

			Log.Logger.Information("Application Starting");

			Log.Information("Starting host...");
			CreateHostBuilder(args)
				.UseSerilog()
				.Build()
				.Run();
		}
		static void BuildConfiguration(IConfigurationBuilder builder)
		{
			builder.SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)			 
			   .AddEnvironmentVariables();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
		   Host.CreateDefaultBuilder(args)
			   .ConfigureWebHostDefaults(webBuilder =>
			   {
				   webBuilder.UseStartup<Startup>();
			   });

		
	}
}

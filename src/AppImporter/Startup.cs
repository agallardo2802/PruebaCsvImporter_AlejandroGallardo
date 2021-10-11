using Application.Configurations;
using Application.Service;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppImporter
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ArchiveOptions>(Configuration.GetSection("ArchiveOptions"));
			services.AddScoped<IImporterCsvService, ImporterCsvService>();
			services.AddScoped<IBulckCopy, BulckCopy>();
			services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IImporterCsvService importerCsvService)
		{
			app.UseDeveloperExceptionPage();

			importerCsvService.MigrateCsvToTable();
		}
	}
}
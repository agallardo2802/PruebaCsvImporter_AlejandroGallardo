using Application.Configurations;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Application.Service
{
	public class ImporterCsvService : IImporterCsvService
	{	
		private readonly ArchiveOptions archiveOptions;	
		private readonly IBulckCopy bulckCopy;

		public ImporterCsvService(IOptions<ArchiveOptions> archiveOptions, IBulckCopy bulckCopy)
		{
			this.archiveOptions = archiveOptions.Value;			
			this.bulckCopy = bulckCopy;
		}

		public string MigrateCsvToTable()
		{
			try
			{
				var timeProccess = new Stopwatch();
				timeProccess.Start();

				Log.Information("Starting download csv..");

				var nameCsv = Path.GetFileName(archiveOptions.ArchiveCsvRoute);
				Log.Information("Csv Name: " + nameCsv);

				string routeCsv = Directory.GetCurrentDirectory() + @"\CsvFilesTemp\" + nameCsv;
				ObtainFile(routeCsv);

				bulckCopy.LoadCsvDataIntoSqlServer(routeCsv, archiveOptions.TableNameSave, archiveOptions.BatchSize, archiveOptions.SeparatorChar);

				timeProccess.Stop();
				Log.Information("Process finish in " + timeProccess.Elapsed.TotalMinutes + " Minutes");

				return "Ok";
			}
			catch (Exception error)
			{
				Log.Error("Process failed, Error: " + error);
				return "Error";
			}			
		}

		private void ObtainFile(string routeCsv)
		{
			if (!File.Exists(routeCsv))
			{
				WebClient wc = new WebClient();
				wc.DownloadFile(archiveOptions.ArchiveCsvRoute, routeCsv);

				Log.Information("Finish download csv");
			}
			else
			{
				Log.Information("Csv already exist in temp folder");
			}
		}
	}
}

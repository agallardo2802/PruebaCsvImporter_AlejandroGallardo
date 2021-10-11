using Application.Configurations;
using Application.Service;
using Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsvImporter.Integrations.Tests
{
	[TestClass]
	public class LoadCsvDataIntoSqlServerTest
	{
		private readonly IOptions<ArchiveOptions> archiveOptions;
		private readonly IBulckCopy bulckCopy;
		private readonly IImporterCsvService importerCsv;
		
		public LoadCsvDataIntoSqlServerTest()
		{		
			bulckCopy = new BulckCopy(new ApplicationDbContext());
			archiveOptions = Options.Create(ObtainOptions());
			importerCsv = new ImporterCsvService(archiveOptions, bulckCopy);
		}
		
		[TestMethod]
		public void Migrate_Test()
		{	
			var value = importerCsv.MigrateCsvToTable(); 

			NUnit.Framework.Assert.AreEqual("Ok",value);			
		}

		private static ArchiveOptions ObtainOptions()
		{
			return new ArchiveOptions()
			{
				ArchiveCsvRoute = @"C:\Users\aleja\source\projects\CsvImporter\src\CsvImporter.Units.Tests\FileTest\StockTest.CSV",
				SeparatorChar = ';',
				BatchSize = 100000,
				TableNameSave = "TStock"
			};
		}
	}
}

using Application.Configurations;
using Application.Service;
using Infrastructure;
using Microsoft.Extensions.Options;
using Xunit;

namespace CsvImporter.Integrations.Tests
{	
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

		[Fact]
		public void Migrate_Test()
		{
			// Act
			var value = importerCsv.MigrateCsvToTable();
			
			// Act and Assert
			Assert.NotNull(value);
			Assert.Equal("Ok", value);
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

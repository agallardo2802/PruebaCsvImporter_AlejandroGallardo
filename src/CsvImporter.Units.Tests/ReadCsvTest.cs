using Domain.Entities;
using LINQtoCSV;
using Xunit;

namespace CsvImporter.Units.Tests
{
	public class ReadCsvTest
	{
		[Fact]
		public void ReedCsv()
		{
			// Arrange			
			var csvContext = new CsvContext();
			CsvFileDescription inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = ';',
				FirstLineHasColumnNames = true,
				FileCultureName = "es-ES",
				EnforceCsvColumnAttribute = true
			};

			// Act
			var read = csvContext.Read<TStock>(@"C:\Users\aleja\source\projects\CsvImporter\src\CsvImporter.Units.Tests\FileTest\StockTest.CSV", inputFileDescription);

			// Act and Assert
			Assert.NotNull(read);			
		}
	}	
}

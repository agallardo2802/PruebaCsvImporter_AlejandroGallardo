using Domain.Entities;
using LINQtoCSV;
using System;
using System.IO;
using Xunit;

namespace CsvImporter.Units.Tests
{
	public class WriteCsvTest
	{
		[Fact]
		public void WriteCsv()
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
			//Setups
			var listAdd = new[] {
				new TStock () { PointOfSale = "5654q", Product= "zzzzz", Date= new DateTime(2021, 9, 23), Stock = 10},
				new TStock () { PointOfSale = "324d", Product= "eeee", Date= new DateTime(2021, 9, 25), Stock = 5},
				new TStock () { PointOfSale = "asda2", Product= "rrrr", Date= new DateTime(2021, 9, 28), Stock = 4}
			};

			// Act
			var result = TestWrite(inputFileDescription, listAdd);

			// Act and Assert
			Assert.NotNull(result);			
		}
		public string TestWrite(CsvFileDescription inputFileDescription, TStock[] listAdd)
		{
			TextWriter stream = new StringWriter();
			CsvContext cc = new CsvContext();
			cc.Write(listAdd, stream, inputFileDescription);
			return stream.ToString();
		}
	}	
}

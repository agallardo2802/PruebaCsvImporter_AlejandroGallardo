using LINQtoCSV;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Entities
{
	[Keyless]
	public class TStock
	{
		[CsvColumn(Name = "PointOfSale", FieldIndex = 1)]
		public string PointOfSale { get; set; }
		[CsvColumn(Name = "Product", FieldIndex = 2)]
		public string Product { get; set; }
		[CsvColumn(Name = "Date", FieldIndex = 3, OutputFormat = "yyyy-MM-dd")]
		public DateTime Date { get; set; }
		[CsvColumn(Name = "Stock", FieldIndex = 4)]
		public int Stock { get; set; }
	}
}

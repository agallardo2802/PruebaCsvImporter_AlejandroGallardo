using Domain;
using Domain.Entities;
using EFCore.BulkExtensions;
using Infrastructure;
using LINQtoCSV;
using Serilog;
using System;
using System.Linq;

namespace Application.Service
{
	public class BulckCopy : IBulckCopy
	{
		private readonly ApplicationDbContext dbContext;

		public BulckCopy(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void LoadCsvDataIntoSqlServer(string fileName, string nameTable, int batchSize, char separatorCsv)
		{
			var countAdded = 0;
			try
			{				
				CsvContext csvContext;
				CsvFileDescription inputFileDescription;
				NewContext(out csvContext, out inputFileDescription, separatorCsv);

				Log.Information("Obtain data to csv");
				var rowsCsvFile = csvContext.Read<TStock>(fileName, inputFileDescription);
								
				Log.Information("Start parse data Csv in List");

				var listRowCsv = rowsCsvFile.ToList().SplitList(batchSize);

				Log.Information("Destination Table " + nameTable);

				using (var context = dbContext)
				{
					Log.Information("Clean table: " + nameTable);
					context.Truncate<TStock>();				

					Log.Information("Copy data in table: " + nameTable);

					foreach (var saveList in listRowCsv)
					{
						context.BulkInsert(saveList);
						countAdded += saveList.Count();

						Log.Information("Progress copy count: " + countAdded);
					}
				}

				Log.Information("End copy data, total rows imported");
			}
			catch (Exception error)
			{
				Log.Error("Error to import, error: " + error);
			}
		}

		private static void NewContext(out CsvContext csvContext, out CsvFileDescription inputFileDescription, char separatorCsv)
		{
			csvContext = new CsvContext();
			inputFileDescription = new CsvFileDescription
			{
				SeparatorChar = separatorCsv,
				FirstLineHasColumnNames = true,
				// default is the current culture
				FileCultureName = "es-ES", 
				EnforceCsvColumnAttribute = true
			};
		}
	}
}

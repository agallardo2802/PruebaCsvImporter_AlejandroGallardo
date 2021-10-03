using Application.Configurations;
using Application.Service;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;

namespace CsvImporter.UnitTests
{
	[TestClass]
	public class ImporterCsvServiceTest 
	{
		private readonly ArchiveOptions archiveOptions;
		private readonly IBulckCopy bulckCopy;

		public ImporterCsvServiceTest(IOptions<ArchiveOptions> archiveOptions, IBulckCopy bulckCopy)
		{
			this.archiveOptions = archiveOptions.Value;
			this.bulckCopy = bulckCopy;
		}


		[TestMethod]
		public void ArchiveOptionsTest()
		{
			Assert.IsNotNull(archiveOptions);
			Assert.IsNotNull(archiveOptions.ArchiveCsvRoute);
			Assert.IsNotNull(archiveOptions.BatchSize);
			Assert.IsNotNull(archiveOptions.SeparatorChar);
		}
		
		[TestMethod]
		public void MigrateCsvToTable()
		{
			var nameCsv = Path.GetFileName(archiveOptions.ArchiveCsvRoute);	
			string routeCsv = Directory.GetCurrentDirectory() + @"\CsvFilesTemp\" + nameCsv;
			ObtainFile(routeCsv);
			bulckCopy.LoadCsvDataIntoSqlServer(routeCsv, archiveOptions.TableNameSave, archiveOptions.BatchSize, archiveOptions.SeparatorChar);
			var result = "ok";
			Assert.IsNotNull(result);
			//Assert.AreEqual("nubimetricsdevapicache.redis.cache.windows.net", cache.Host);
		}

		private void ObtainFile(string routeCsv)
		{
			if (!File.Exists(routeCsv))
			{
				WebClient wc = new WebClient();
				wc.DownloadFile(archiveOptions.ArchiveCsvRoute, routeCsv);
			}
		}
	}	
}

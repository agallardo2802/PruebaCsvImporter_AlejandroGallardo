namespace Application.Service
{
	public interface IBulckCopy
	{
		public void LoadCsvDataIntoSqlServer(string fileName, string nameTable, int batchSize, char separatorCsv);
	}
}
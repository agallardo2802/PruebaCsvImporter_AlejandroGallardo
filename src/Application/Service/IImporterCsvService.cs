using System.Threading.Tasks;

namespace Application.Service
{
	public interface IImporterCsvService
	{
		public string MigrateCsvToTable();
	}
}

namespace Application.Configurations
{
	public class ArchiveOptions
	{
		public string ArchiveCsvRoute { get; set; }
		public int BatchSize { get; set; }
		public string TableNameSave { get; set; }
		public char SeparatorChar { get; set; }		
	}
}

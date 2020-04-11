namespace OpenRA.ModMaker.Model
{
	public class Mod
	{
		public string WorkingDirectoryPath { get; }
		public string ModsDirectoryPath { get; }
		public string ModId { get; }
		public Manifest Manifest { get; }

		public Mod(string workingDirectoryPath, string modsDirectoryPath, string modId)
		{
			this.WorkingDirectoryPath = workingDirectoryPath;
			this.ModsDirectoryPath = modsDirectoryPath;
			this.ModId = modId;

			this.Manifest = new Manifest(this);
		}
	}
}

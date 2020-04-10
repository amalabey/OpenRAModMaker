namespace OpenRA.ModMaker.Data
{
	public interface IModFileStore
	{
		Manifest ReadManifest(string path, string modId);
	}
}

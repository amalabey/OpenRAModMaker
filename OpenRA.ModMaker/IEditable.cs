namespace OpenRA.ModMaker
{
	public interface IEditable
	{
		bool IsDirty { get; }
		string Path { get; set; }
		void Load();
		void Save();
	}
}

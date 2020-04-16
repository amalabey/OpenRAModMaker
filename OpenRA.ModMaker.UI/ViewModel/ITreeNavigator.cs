namespace OpenRA.ModMaker.UI.ViewModel
{
	public interface ITreeNavigator
	{
		TreeViewNode Root { get; set; }
		TreeViewNode SelectedNode { get; set; }
		void FindNext(string keyword);
		void FindPrevious(string keyword);
	}
}

using OpenRA.ModMaker.UI.ViewModel;

namespace OpenRA.ModMaker.UI.Services
{
	public interface ITreeNavigator
	{
		TreeViewNode Root { get; set; }
		TreeViewNode SelectedNode { get; set; }
		void FindNext(string keyword);
		void FindPrevious(string keyword);
		void NavigateTo<T>(string name);
	}
}

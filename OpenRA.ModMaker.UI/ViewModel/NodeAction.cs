using System.Windows.Input;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class NodeAction
	{
		public string Name { get; set; }
		public ICommand Command { get; set; }
	}
}

using System.ComponentModel;
using OpenRA.ModMaker.UI.Dialogs.TextInput;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public delegate void AttributeAddedEventHandler(TreeViewNode node);
	public delegate void NodeSelectedEventHandler(TreeViewNode node);

	public interface IMediator
	{
		event AttributeAddedEventHandler AttributeAdded;
		event NodeSelectedEventHandler NodeSelected;

		void NotifyAttributeAdded(TreeViewNode node);
		void NotifyNodeSelected(TreeViewNode node);
	}
}

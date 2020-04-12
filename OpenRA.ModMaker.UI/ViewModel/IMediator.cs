using System.ComponentModel;
using OpenRA.ModMaker.UI.Dialogs.TextInput;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public delegate void AttributeAddedEventHandler(TreeViewNode node);

	public interface IMediator
	{
		event AttributeAddedEventHandler AttributeAdded;
		void NotifyAttributeAdded(TreeViewNode node);
	}
}

using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.UI.Dialogs.TextInput;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class Mediator : IMediator
	{
		public event AttributeAddedEventHandler AttributeAdded = (node) => { };

		public void NotifyAttributeAdded(TreeViewNode node)
		{
			AttributeAdded(node);
		}
	}
}

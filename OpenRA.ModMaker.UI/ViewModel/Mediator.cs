using System;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class Mediator : IMediator
	{
		public event AttributeAddedEventHandler AttributeAdded = (node) => { };
		public event NodeSelectedEventHandler NodeSelected;
		public event ActorNavigationRequestedHandler ActorNavigationRequested;

		public void NotifyAttributeAdded(TreeViewNode node)
		{
			AttributeAdded(node);
		}

		public void NotifyActorNavigationRequested(string nodeName)
		{
			ActorNavigationRequested(nodeName);
		}

		public void NotifyNodeSelected(TreeViewNode node)
		{
			NodeSelected(node);
		}
	}
}

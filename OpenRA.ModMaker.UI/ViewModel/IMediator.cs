using System;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public delegate void AttributeAddedEventHandler(TreeViewNode node);
	public delegate void NodeSelectedEventHandler(TreeViewNode node);
	public delegate void ActorNavigationRequestedHandler(string name);

	public interface IMediator
	{
		event AttributeAddedEventHandler AttributeAdded;
		event NodeSelectedEventHandler NodeSelected;
		event ActorNavigationRequestedHandler ActorNavigationRequested;

		void NotifyAttributeAdded(TreeViewNode node);
		void NotifyNodeSelected(TreeViewNode node);
		void NotifyActorNavigationRequested(string nodeName);
	}
}

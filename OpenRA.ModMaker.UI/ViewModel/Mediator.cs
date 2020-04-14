namespace OpenRA.ModMaker.UI.ViewModel
{
	public class Mediator : IMediator
	{
		public event AttributeAddedEventHandler AttributeAdded = (node) => { };
		public event NodeSelectedEventHandler NodeSelected;

		public void NotifyAttributeAdded(TreeViewNode node)
		{
			AttributeAdded(node);
		}

		public void NotifyNodeSelected(TreeViewNode node)
		{
			NodeSelected(node);
		}
	}
}

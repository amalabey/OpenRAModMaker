namespace OpenRA.ModMaker.UI.ViewModel
{
	public class MediatorContext : IMediatorContext
	{
		public event AttributeAddedEventHandler AttributeAdded = (node) => { };

		public void NotifyAttributeAdded(TreeViewNode node)
		{
			AttributeAdded(node);
		}
	}
}

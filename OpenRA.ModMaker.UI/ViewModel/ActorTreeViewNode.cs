using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ActorTreeViewNode : TreeViewNode
	{
		public ActorTreeViewNode(OpenRA.ModMaker.Model.Actor node, IMediatorContext context) : base(node, context)
		{
			if(node.Children != null)
			{
				foreach (var trait in node.Children)
				{
					this.Children.Add(new TraitTreeViewNode((Trait)trait, context));
				}
			}
		}

		public override string Image => "actor.png";
	}
}

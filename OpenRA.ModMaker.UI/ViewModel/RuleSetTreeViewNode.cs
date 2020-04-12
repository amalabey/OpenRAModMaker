using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetTreeViewNode : TreeViewNode
	{
		public RuleSetTreeViewNode(RuleSet node, IMediatorContext context) : base(node, context)
		{
			if (node.Children != null)
			{
				foreach (var actor in node.Children)
				{
					this.Children.Add(new ActorTreeViewNode((OpenRA.ModMaker.Model.Actor)actor, context));
				}
			}
		}

		public override string Image => "ruleset.png";
	}
}

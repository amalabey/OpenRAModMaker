using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetCollectionTreeViewNode : TreeViewNode
	{
		public RuleSetCollectionTreeViewNode(RuleSetCollection node, IMediatorContext context) : base(node, context)
		{
			if (node.Children != null)
			{
				foreach (var ruleSet in node.Children)
				{
					this.Children.Add(new RuleSetTreeViewNode((OpenRA.ModMaker.Model.RuleSet)ruleSet, context));
				}
			}
		}

		public override string Image => "rulesetcollection.png";
	}
}

using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetCollectionTreeViewNode : TreeViewNode
	{
		public RuleSetCollectionTreeViewNode(RuleSetCollection modDefinitionNode) : base(modDefinitionNode)
		{
			if (modDefinitionNode.Children != null)
			{
				foreach (var ruleSet in modDefinitionNode.Children)
				{
					this.Children.Add(new RuleSetTreeViewNode((OpenRA.ModMaker.Model.RuleSet)ruleSet));
				}
			}
		}

		public override string Image => "rulesetcollection.png";
	}
}

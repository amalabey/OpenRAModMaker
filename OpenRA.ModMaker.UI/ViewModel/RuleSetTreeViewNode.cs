using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetTreeViewNode : TreeViewNode
	{
		public RuleSetTreeViewNode(RuleSet modDefinitionNode) : base(modDefinitionNode)
		{
			if (modDefinitionNode.Children != null)
			{
				foreach (var actor in modDefinitionNode.Children)
				{
					this.Children.Add(new ActorTreeViewNode((OpenRA.ModMaker.Model.Actor)actor));
				}
			}
		}

		public override string Image => "ruleset.png";
	}
}

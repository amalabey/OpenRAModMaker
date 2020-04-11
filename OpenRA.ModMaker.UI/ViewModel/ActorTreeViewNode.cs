using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ActorTreeViewNode : TreeViewNode
	{
		public ActorTreeViewNode(OpenRA.ModMaker.Model.Actor modDefinitionNode) : base(modDefinitionNode)
		{
			if(modDefinitionNode.Children != null)
			{
				foreach (var trait in modDefinitionNode.Children)
				{
					this.Children.Add(new TraitTreeViewNode((Trait)trait));
				}
			}
		}

		public override string Image => "images/actor.jpg";
	}
}

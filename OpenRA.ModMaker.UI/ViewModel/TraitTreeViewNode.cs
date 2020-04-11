using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TraitTreeViewNode : TreeViewNode
	{
		public TraitTreeViewNode(Trait modDefinitionNode) : base(modDefinitionNode)
		{
		}

		public override string Image => "trait.png";
	}
}

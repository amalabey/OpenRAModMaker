using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TraitTreeViewNode : TreeViewNode
	{
		public TraitTreeViewNode(Trait node, IMediatorContext context) : base(node, context)
		{
		}

		public override string Image => "trait.png";
	}
}

using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class PackagesTreeViewNode : TreeViewNode
	{
		public PackagesTreeViewNode(Packages packagesNode, IMediatorContext context) : base(packagesNode, context)
		{
		}

		public override string Image => "packages.png";
	}
}

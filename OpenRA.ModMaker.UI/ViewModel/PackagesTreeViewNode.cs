using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class PackagesTreeViewNode : TreeViewNode
	{
		public PackagesTreeViewNode(Packages packagesNode) : base(packagesNode)
		{
		}

		public override string Image => "images/packages.jpg";
	}
}

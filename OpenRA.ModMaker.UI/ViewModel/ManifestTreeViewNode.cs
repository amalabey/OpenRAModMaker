using System.Linq;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ManifestTreeViewNode : TreeViewNode
	{
		public ManifestTreeViewNode(OpenRA.ModMaker.Model.Manifest manifestNode) : base(manifestNode)
		{
			var packagesNode = manifestNode.Children.FirstOrDefault(x => x.Name == Constants.PackagesNodeName);
			if(packagesNode != null)
			{
				this.Children.Add(new PackagesTreeViewNode((Packages)packagesNode));
			}

			var rulesNode = manifestNode.Children.FirstOrDefault(x => x.Name == Constants.RulesNodeName);
			if (rulesNode != null)
			{
				this.Children.Add(new RuleSetCollectionTreeViewNode((RuleSetCollection)rulesNode));
			}
		}
	}
}

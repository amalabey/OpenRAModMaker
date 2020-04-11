using System.Collections.Concurrent;
using System.Linq;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Adapters;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ManifestTreeViewNode : TreeViewNode
	{
		public DictionaryPropertyGridAdapter<string, object> SelectedAttributeSet { get; set; }

		public ManifestTreeViewNode(OpenRA.ModMaker.Model.Manifest manifestNode) : base(manifestNode)
		{
			this.SelectedAttributeSet = new DictionaryPropertyGridAdapter<string, object>(this.Attributes);

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

		protected override void OnNodeSelection(object parameter)
		{
			this.SelectedAttributeSet = new DictionaryPropertyGridAdapter<string, object>(((TreeViewNode)parameter).Attributes);
		}
	}
}

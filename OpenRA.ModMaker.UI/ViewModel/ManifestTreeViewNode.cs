using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Input;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Adapters;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ManifestTreeViewNode : TreeViewNode
	{
		public ICommand SaveCommand { get; set; }
		public DictionaryPropertyGridAdapter<string, object> SelectedAttributeSet { get; set; }

		public ManifestTreeViewNode(OpenRA.ModMaker.Model.Manifest manifestNode) : base(manifestNode)
		{
			this.SelectedAttributeSet = new DictionaryPropertyGridAdapter<string, object>(this.Attributes);
			this.SaveCommand = new RelayCommand<object>(OnSave, p => true);

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

		private void OnSave(object parameter)
		{
			this.node.SaveState();
		}

		protected override void OnNodeSelection(object parameter)
		{
			this.SelectedAttributeSet = new DictionaryPropertyGridAdapter<string, object>(((TreeViewNode)parameter).Attributes);
		}
	}
}

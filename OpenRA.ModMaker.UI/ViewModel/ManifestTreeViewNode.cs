using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Primitives;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ManifestTreeViewNode : TreeViewNode
	{
		public ICommand SaveCommand { get; set; }

		public ManifestTreeViewNode(TreeViewNode parent, OpenRA.ModMaker.Model.Manifest node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, navigator, ownerViewModel, dialogService)
		{
			this.Name = "";
			this.SaveCommand = new RelayCommand<object>(OnSave, p => true);

			var packagesNode = node.Children.FirstOrDefault(x => x.Name == NodeNames.PackagesNodeName);
			if(packagesNode != null)
			{
				this.Children.Add(new PackagesTreeViewNode(this, (Packages)packagesNode, navigator, ownerViewModel, dialogService));
			}

			var rulesNode = node.Children.FirstOrDefault(x => x.Name == NodeNames.RulesNodeName);
			if (rulesNode != null)
			{
				this.Children.Add(new RuleSetCollectionTreeViewNode(this, (RuleSetCollection)rulesNode, navigator, ownerViewModel, dialogService));
			}
		}

		private void OnSave(object parameter)
		{
			this.node.SaveState();
		}
	}
}

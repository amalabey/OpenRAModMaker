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
		public AttributeDictionary<string, object> SelectedAttributeSet { get; set; }

		public ManifestTreeViewNode(OpenRA.ModMaker.Model.Manifest node, Mediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(node, context, ownerViewModel, dialogService)
		{
			this.SaveCommand = new RelayCommand<object>(OnSave, p => true);

			var packagesNode = node.Children.FirstOrDefault(x => x.Name == Constants.PackagesNodeName);
			if(packagesNode != null)
			{
				this.Children.Add(new PackagesTreeViewNode((Packages)packagesNode, context, ownerViewModel, dialogService));
			}

			var rulesNode = node.Children.FirstOrDefault(x => x.Name == Constants.RulesNodeName);
			if (rulesNode != null)
			{
				this.Children.Add(new RuleSetCollectionTreeViewNode((RuleSetCollection)rulesNode, context, ownerViewModel, dialogService));
			}
		}

		private void OnSave(object parameter)
		{
			this.node.SaveState();
		}
	}
}

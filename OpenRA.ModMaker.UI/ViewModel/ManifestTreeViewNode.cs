using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.Adapters;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ManifestTreeViewNode : TreeViewNode
	{
		public ICommand SaveCommand { get; set; }
		public DictionaryPropertyGridAdapter<string, object> SelectedAttributeSet { get; set; }

		public ManifestTreeViewNode(OpenRA.ModMaker.Model.Manifest node, Mediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(node, context, ownerViewModel, dialogService)
		{
			this.SelectedAttributeSet = new DictionaryPropertyGridAdapter<string, object>(this.Attributes);
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

			context.AttributeAdded += TreeNodeAttributeAdded;
		}

		private void TreeNodeAttributeAdded(TreeViewNode node)
		{
			this.SelectedAttributeSet = new DictionaryPropertyGridAdapter<string, object>(node.Attributes);
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

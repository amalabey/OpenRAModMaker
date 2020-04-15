using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TraitTreeViewNode : TreeViewNode
	{
		public TraitTreeViewNode(TreeViewNode parent, Trait node, IMediator mediator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, mediator, ownerViewModel, dialogService)
		{
			if (!string.IsNullOrEmpty(node.Value))
			{
				this.Link = $"{node.Name} - {node.Value}";
			}
		}

		protected override void OnLinkClicked(object parameter)
		{
			mediator.NotifyActorNavigationRequested(this.Value);
		}

		public override string Image => "trait.png";
	}
}

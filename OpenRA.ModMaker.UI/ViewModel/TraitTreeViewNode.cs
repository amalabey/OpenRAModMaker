using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TraitTreeViewNode : TreeViewNode
	{
		public TraitTreeViewNode(TreeViewNode parent, Trait node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider) 
	  		: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider)
		{
			if (!string.IsNullOrEmpty(node.Value))
			{
				this.Link = $"{node.Name} - {node.Value}";
			}
		}

		protected override void OnLinkClicked(object parameter)
		{
			this.navigator.NavigateTo<ActorTreeViewNode>(this.Value);
		}

		public override string IconUrl => "trait.png";
	}
}

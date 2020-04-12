using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TraitTreeViewNode : TreeViewNode
	{
		public TraitTreeViewNode(Trait node, IMediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(node, context, ownerViewModel, dialogService)
		{
		}

		public override string Image => "trait.png";
	}
}

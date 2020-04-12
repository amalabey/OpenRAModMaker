using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class PackagesTreeViewNode : TreeViewNode
	{
		public PackagesTreeViewNode(Packages packagesNode, IMediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(packagesNode, context, ownerViewModel, dialogService)
		{
		}

		public override string Image => "packages.png";
	}
}

using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class PackagesTreeViewNode : TreeViewNode
	{
		public PackagesTreeViewNode(TreeViewNode parent, Packages packagesNode, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider,
			IResourceProvider resourceProvider, IUIContext uiContext) 
			: base(parent, packagesNode, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext)
		{
		}

		public override string IconUrl => "packages.png";
	}
}

using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class WeaponSetCollectionTreeViewNode : TreeViewNode
	{
		public WeaponSetCollectionTreeViewNode(TreeViewNode parent, WeaponSetCollection node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, 
			IDialogService dialogService, IContentProvider contentProvider, IResourceProvider resourceProvider, IUIContext uiContext)
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext)
		{
			if (node.Children != null)
			{
				foreach (var weaponSet in node.Children)
				{
					this.Children.Add(new WeaponSetTreeViewNode(this, (OpenRA.ModMaker.Model.WeaponSet)weaponSet, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext));
				}
			}
		}

		public override string IconUrl => "weaponsetcollection.png";
	}
}

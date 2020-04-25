using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class WeaponSetCollectionTreeViewNode : TreeViewNode
	{
		public WeaponSetCollectionTreeViewNode(TreeViewNode parent, WeaponSetCollection node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, 
			IDialogService dialogService, IContentProvider contentProvider)
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider)
		{
			if (node.Children != null)
			{
				foreach (var weaponSet in node.Children)
				{
					this.Children.Add(new WeaponSetTreeViewNode(this, (OpenRA.ModMaker.Model.WeaponSet)weaponSet, navigator, ownerViewModel, dialogService, contentProvider));
				}
			}
		}

		public override string IconUrl => "weaponsetcollection.png";
	}
}

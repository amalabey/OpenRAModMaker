using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class WeaponSetTreeViewNode : TreeViewNode
	{
		public WeaponSetTreeViewNode(TreeViewNode parent, WeaponSet node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider,
			IResourceProvider resourceProvider, IUIContext uiContext) 
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext)
		{
			if (node.Children != null)
			{
				foreach (var weapon in node.Children)
				{
					this.Children.Add(new WeaponTreeViewNode(this, (OpenRA.ModMaker.Model.Weapon)weapon, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext));
				}
			}
		}

		public override string IconUrl => "ruleset.png";
	}
}

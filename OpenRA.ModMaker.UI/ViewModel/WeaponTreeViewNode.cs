using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class WeaponTreeViewNode : TreeViewNode
	{
		public WeaponTreeViewNode(TreeViewNode parent, OpenRA.ModMaker.Model.Weapon node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider,
			IResourceProvider resourceProvider, IUIContext uiContext)
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext)
		{
			if (node.Children != null)
			{
				foreach (var trait in node.Children)
				{
					this.Children.Add(new TraitTreeViewNode(this, (Trait)trait, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext));

					if (trait.Name == TraitNames.TooltipTraitName)
					{
						if (trait.Attributes != null && trait.Attributes.ContainsKey("Name"))
						{
							this.Name = $"{node.Name} : ({trait.Attributes["Name"]})";
						}
					}
				}
			}
		}

		public override string IconUrl => "weapon.png";
	}
}

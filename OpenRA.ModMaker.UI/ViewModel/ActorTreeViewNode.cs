using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ActorTreeViewNode : TreeViewNode
	{
		private const string DefaultSequenceName = "idle";
		private SpriteImageViewModel image;

		public ActorTreeViewNode(TreeViewNode parent, OpenRA.ModMaker.Model.Actor node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider,
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

		public override SpriteImageViewModel Icon
		{
			get
			{
				if (image == null)
					image = new SpriteImageViewModel(contentProvider, resourceProvider, uiContext, this.node.Name, DefaultSequenceName);

				return image;
			}
		}

		public override string IconUrl => "actor.png";
	}
}

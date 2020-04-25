using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class WeaponTreeViewNode : TreeViewNode
	{
		//private const string DefaultTileSetName = "SNOW";
		//private const string DefaultSequenceName = "idle";
		//private ImageViewModel image;

		public WeaponTreeViewNode(TreeViewNode parent, OpenRA.ModMaker.Model.Weapon node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider)
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider)
		{
			if (node.Children != null)
			{
				foreach (var trait in node.Children)
				{
					this.Children.Add(new TraitTreeViewNode(this, (Trait)trait, navigator, ownerViewModel, dialogService, contentProvider));

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

		//public override ImageViewModel Icon
		//{
		//	get
		//	{
		//		if (image == null)
		//			image = GetSpriteImage();

		//		return image;
		//	}
		//}

		//private ImageViewModel GetSpriteImage()
		//{
		//	try
		//	{
		//		var sequence = contentProvider.GetSpriteSequence(DefaultTileSetName, this.node.Name, (x) => x.FirstOrDefault(y => y == DefaultSequenceName) ?? x.FirstOrDefault());
		//		if (sequence != null && sequence.Sprites != null && sequence.Sprites.Length > 0)
		//		{
		//			var spriteImage = sequence.Sprites[0];
		//			var data = spriteImage.RawData.Value;
					
		//			return new ImageViewModel(data, spriteImage.Width, spriteImage.Height);
		//		}

		//		return null;
		//	}
		//	catch (System.Exception)
		//	{
		//		return null;
		//	}
		//}

		public override string IconUrl => "weapon.png";
	}
}

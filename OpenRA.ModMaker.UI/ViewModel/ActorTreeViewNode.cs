using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ActorTreeViewNode : TreeViewNode
	{
		public ActorTreeViewNode(TreeViewNode parent, OpenRA.ModMaker.Model.Actor node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, navigator, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var trait in node.Children)
				{
					this.Children.Add(new TraitTreeViewNode(this, (Trait)trait, navigator, ownerViewModel, dialogService));
				
					if(trait.Name == TraitNames.TooltipTraitName)
					{
						if(trait.Attributes != null && trait.Attributes.ContainsKey("Name"))
						{
							this.Name = $"{node.Name} : ({trait.Attributes["Name"]})";
						}
					}
				}
			}
		}

		public override string Image => "actor.png";
	}
}

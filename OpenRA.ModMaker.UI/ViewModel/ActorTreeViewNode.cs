using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ActorTreeViewNode : TreeViewNode
	{
		public ActorTreeViewNode(TreeViewNode parent, OpenRA.ModMaker.Model.Actor node, IMediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, context, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var trait in node.Children)
				{
					this.Children.Add(new TraitTreeViewNode(this, (Trait)trait, context, ownerViewModel, dialogService));
				}
			}
		}

		public override string Image => "actor.png";
	}
}

using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class ActorTreeViewNode : TreeViewNode
	{
		public ActorTreeViewNode(OpenRA.ModMaker.Model.Actor node, IMediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(node, context, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var trait in node.Children)
				{
					this.Children.Add(new TraitTreeViewNode((Trait)trait, context, ownerViewModel, dialogService));
				}
			}
		}

		public override string Image => "actor.png";
	}
}

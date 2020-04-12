using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetTreeViewNode : TreeViewNode
	{
		public RuleSetTreeViewNode(RuleSet node, IMediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(node, context, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var actor in node.Children)
				{
					this.Children.Add(new ActorTreeViewNode((OpenRA.ModMaker.Model.Actor)actor, context, ownerViewModel, dialogService));
				}
			}
		}

		public override string Image => "ruleset.png";
	}
}

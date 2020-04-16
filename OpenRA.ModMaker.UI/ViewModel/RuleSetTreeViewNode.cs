using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetTreeViewNode : TreeViewNode
	{
		public RuleSetTreeViewNode(TreeViewNode parent, RuleSet node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, navigator, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var actor in node.Children)
				{
					this.Children.Add(new ActorTreeViewNode(this, (OpenRA.ModMaker.Model.Actor)actor, navigator, ownerViewModel, dialogService));
				}
			}
		}

		public override string Image => "ruleset.png";
	}
}

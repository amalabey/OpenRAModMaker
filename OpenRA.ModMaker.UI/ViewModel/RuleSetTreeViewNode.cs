using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetTreeViewNode : TreeViewNode
	{
		public RuleSetTreeViewNode(TreeViewNode parent, RuleSet node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider) 
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider)
		{
			if (node.Children != null)
			{
				foreach (var actor in node.Children)
				{
					this.Children.Add(new ActorTreeViewNode(this, (OpenRA.ModMaker.Model.Actor)actor, navigator, ownerViewModel, dialogService, contentProvider));
				}
			}
		}

		public override string IconUrl => "ruleset.png";
	}
}

using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetCollectionTreeViewNode : TreeViewNode
	{
		public RuleSetCollectionTreeViewNode(TreeViewNode parent, RuleSetCollection node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, navigator, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var ruleSet in node.Children)
				{
					this.Children.Add(new RuleSetTreeViewNode(this, (OpenRA.ModMaker.Model.RuleSet)ruleSet, navigator, ownerViewModel, dialogService));
				}
			}
		}

		public override string Image => "rulesetcollection.png";
	}
}

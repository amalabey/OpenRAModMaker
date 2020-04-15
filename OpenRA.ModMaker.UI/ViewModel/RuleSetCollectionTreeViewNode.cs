using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetCollectionTreeViewNode : TreeViewNode
	{
		public RuleSetCollectionTreeViewNode(TreeViewNode parent, RuleSetCollection node, IMediator context, INotifyPropertyChanged ownerViewModel, IDialogService dialogService) 
			: base(parent, node, context, ownerViewModel, dialogService)
		{
			if (node.Children != null)
			{
				foreach (var ruleSet in node.Children)
				{
					this.Children.Add(new RuleSetTreeViewNode(this, (OpenRA.ModMaker.Model.RuleSet)ruleSet, context, ownerViewModel, dialogService));
				}
			}
		}

		public override string Image => "rulesetcollection.png";
	}
}

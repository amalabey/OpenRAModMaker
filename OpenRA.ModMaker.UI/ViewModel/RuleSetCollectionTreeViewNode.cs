using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetCollectionTreeViewNode : TreeViewNode
	{
		public RuleSetCollectionTreeViewNode(TreeViewNode parent, RuleSetCollection node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, 
			IDialogService dialogService, IContentProvider contentProvider, IResourceProvider resourceProvider, IUIContext uiContext)
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext)
		{
			if (node.Children != null)
			{
				foreach (var ruleSet in node.Children)
				{
					this.Children.Add(new RuleSetTreeViewNode(this, (OpenRA.ModMaker.Model.RuleSet)ruleSet, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext));
				}
			}
		}

		public override string IconUrl => "rulesetcollection.png";
	}
}

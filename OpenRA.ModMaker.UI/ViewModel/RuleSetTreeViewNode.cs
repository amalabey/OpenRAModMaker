using System.ComponentModel;
using MvvmDialogs;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Services;
using OpenRA.ModMaker.UI.Services;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class RuleSetTreeViewNode : TreeViewNode
	{
		public RuleSetTreeViewNode(TreeViewNode parent, RuleSet node, ITreeNavigator navigator, INotifyPropertyChanged ownerViewModel, IDialogService dialogService, IContentProvider contentProvider,
			IResourceProvider resourceProvider, IUIContext uiContext) 
			: base(parent, node, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext)
		{
			if (node.Children != null)
			{
				foreach (var actor in node.Children)
				{
					this.Children.Add(new ActorTreeViewNode(this, (OpenRA.ModMaker.Model.Actor)actor, navigator, ownerViewModel, dialogService, contentProvider, resourceProvider, uiContext));
				}
			}
		}

		public override string IconUrl => "ruleset.png";
	}
}

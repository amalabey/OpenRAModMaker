using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Primitives;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNode : BaseViewModel
	{
		protected Node node;
		public string Name { get; set; }
		public virtual string Image { get; }
		public bool IsExpanded { get; set; }
		public ICommand SelectCommand { get; set; }
		public ObservableCollection<TreeViewNode> Children { get; set; }
		public AttributeDictionary<string, object> Attributes { get; set; }
		public ObservableCollection<NodeAction> ContextActions { get; set; }

		public TreeViewNode(Node modDefinitionNode)
		{
			this.Attributes = new AttributeDictionary<string, object>();
			this.Children = new ObservableCollection<TreeViewNode>();
			this.SelectCommand = new RelayCommand<object>(OnNodeSelection, p => true);
			this.node = modDefinitionNode;
			this.Name = modDefinitionNode.Name;

			if (modDefinitionNode.Attributes != null)
			{
				foreach (var attrib in modDefinitionNode.Attributes)
				{
					this.Attributes.Add(attrib.Key, attrib.Value);
				}
			}

			this.Attributes.SyncTo(this.node.Attributes);
			this.ContextActions = new ObservableCollection<NodeAction>
			{
				new NodeAction
				{
					Name = "Add Property",
					Command = new RelayCommand<object>(OnAddAttribute, p => true) }
			};
		}

		private void OnAddAttribute(object parameter)
		{

		}

		protected virtual void OnNodeSelection(object parameter) { }
	}
}

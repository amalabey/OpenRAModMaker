using System.Collections.ObjectModel;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Primitives;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNode : BaseViewModel
	{
		private Node modDefinitionNode;

		public TreeViewNode(Node modDefinitionNode)
		{
			this.Attributes = new AttributeDictionary<string, string>();
			this.Children = new ObservableCollection<TreeViewNode>();

			this.modDefinitionNode = modDefinitionNode;

			this.Name = modDefinitionNode.Name;
			if (modDefinitionNode.Attributes != null)
			{
				foreach (var attrib in modDefinitionNode.Attributes)
				{
					this.Attributes.Add(attrib.Key, attrib.Value);
				}
			}
		}

		public string Name { get; set; }
		public virtual string Image { get; }
		public bool IsExpanded { get; set; }
		public ObservableCollection<TreeViewNode> Children { get; set; }
		public AttributeDictionary<string, string> Attributes { get; set; }
	}
}

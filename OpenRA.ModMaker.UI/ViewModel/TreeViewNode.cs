using System.Collections.ObjectModel;
using System.Windows.Input;
using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.Primitives;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNode : BaseViewModel
	{
		private Node modDefinitionNode;
		public string Name { get; set; }
		public virtual string Image { get; }
		public bool IsExpanded { get; set; }
		public ICommand SelectCommand { get; set; }
		public ObservableCollection<TreeViewNode> Children { get; set; }
		public AttributeDictionary<string, object> Attributes { get; set; }


		public TreeViewNode(Node modDefinitionNode)
		{
			this.Attributes = new AttributeDictionary<string, object>();
			this.Children = new ObservableCollection<TreeViewNode>();
			this.SelectCommand = new RelayCommand<object>(OnNodeSelection, p => true);
			this.modDefinitionNode = modDefinitionNode;
			this.Name = modDefinitionNode.Name;

			if (modDefinitionNode.Attributes != null)
			{
				foreach (var attrib in modDefinitionNode.Attributes)
				{
					this.Attributes.Add(attrib.Key, attrib.Value);
				}
			}

			this.Attributes.OnAdd += (k, v) => this.modDefinitionNode.Attributes.Add(k, v);
			this.Attributes.OnRemove += (k) => this.modDefinitionNode.Attributes.Remove(k);
			this.Attributes.OnSet += (k, v) => this.modDefinitionNode.Attributes[k] = v ;
			this.Attributes.OnClear += () => this.modDefinitionNode.Attributes.Clear();
		}

		protected virtual void OnNodeSelection(object parameter) { }
	}
}

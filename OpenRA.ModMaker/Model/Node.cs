using System.ComponentModel;
using OpenRA.ModMaker.Primitives;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Model
{
	public class Node : INotifyPropertyChanged
	{
		private readonly NodeType nodeType = NodeType.Generic;
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
		private string name;

		public Node(NodeType nodeType)
		{
			this.nodeType = nodeType;
			this.Children = new ObservableCollection<Node>();
			this.Attributes = new AttributeDictionary<string, object>();
		}

		public string Name { 
			get
			{
				return name;
			}
			set
			{
				this.name = value;
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		public virtual NodeType NodeType 
		{
			get
			{
				return nodeType;
			}
		}

		public Node Parent { get; set; }
		public ObservableCollection<Node> Children { get; set; }
		public AttributeDictionary<string, object> Attributes { get; set; }
	}
}

using System.Collections.Generic;
using System.ComponentModel;
using OpenRA.ModMaker.Primitives;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Model
{
	public class Node : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		private string name;
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
				return NodeType.Generic;
			}
		}

		public Node Parent { get; set; }
		public ObservableCollection<Node> Children { get; set; }
		public AttributeDictionary<string, string> Attributes { get; set; }
	}
}

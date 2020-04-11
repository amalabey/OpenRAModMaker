using System.ComponentModel;
using OpenRA.ModMaker.Primitives;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Model
{
	public class Node : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
		private string name;

		public Node()
		{
			this.Children = new ObservableCollection<Node>();
			this.Attributes = new AttributeDictionary<string, object>();
		}

		public string Name 
		{
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

		public virtual void SaveState() 
		{
			if(this.Children != null)
			{
				foreach (var childNode in this.Children)
				{
					childNode.SaveState();
				}
			}
		}

		public ObservableCollection<Node> Children { get; set; }
		public AttributeDictionary<string, object> Attributes { get; set; }
	}
}

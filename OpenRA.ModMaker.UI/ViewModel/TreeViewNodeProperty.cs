using OpenRA.ModMaker.Model;
using OpenRA.ModMaker.UI.ViewModel.Base;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public class TreeViewNodeProperty : BaseViewModel
	{
		private string name;
		private object propValue;
		private readonly Node node;

		public TreeViewNodeProperty(Node node, string propName, object propValue)
		{
			this.node = node;
			this.name = propName;
			this.propValue = propValue;
		}

		public string Name 
		{ 
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public object Value 
		{ 
			get
			{
				return propValue;
			}
			set
			{
				this.node.Attributes[this.Name] = value;
				propValue = value;
			}
		}


	}
}

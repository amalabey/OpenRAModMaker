using System.Linq;
using OpenRA.ModMaker.Extensions;

namespace OpenRA.ModMaker.Model
{
	public class Packages : Node
	{
		private MiniYaml yaml;

		public Packages(MiniYaml yaml)
		{
			Name = "Packages";
			this.yaml = yaml;
			if (yaml != null)
			{
				var attributes = yaml.ToAttributeDictionary<string, string>(s => s, n => n.Value);
				Attributes = attributes;
			}
		}

		public override NodeType NodeType
		{
			get
			{
				return NodeType.Packages;
			}
		}
	}
}

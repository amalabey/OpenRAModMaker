using System.Collections.Generic;
using System.Linq;

namespace OpenRA.ModMaker.Model
{
	public class Manifest : Node
	{
		private List<MiniYamlNode> yamlNodes;

		public override NodeType NodeType
		{
			get
			{
				return NodeType.Manifest;
			}
		}

		public Manifest(string path)
		{
			this.yamlNodes = MiniYaml.FromFile(path, false);
			var packagesNode = new Packages(this.yamlNodes.FirstOrDefault(x => x.Key == "Packages")?.Value);
			this.Children.Add(packagesNode);
		}
	}
}

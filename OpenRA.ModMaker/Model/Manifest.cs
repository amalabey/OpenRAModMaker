using System.Collections.Generic;
using System.Linq;

namespace OpenRA.ModMaker.Model
{
	public class Manifest : Node
	{
		private List<MiniYamlNode> yamlNodes;
		private string yamlFilePath;

		public override NodeType NodeType
		{
			get
			{
				return NodeType.Manifest;
			}
		}

		public Manifest(string path) : base(NodeType.Manifest)
		{
			this.yamlFilePath = path;
			this.yamlNodes = MiniYaml.FromFile(path, false);
			this.Children.Add(new Packages(this.yamlNodes.FirstOrDefault(x => x.Key == "Packages")?.Value));
			this.Children.Add(new RuleSetCollection(this.yamlNodes.FirstOrDefault(x => x.Key == "Rules")?.Value));
		}
	}
}

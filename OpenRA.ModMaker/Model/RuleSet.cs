using System;
using System.Collections.Generic;

namespace OpenRA.ModMaker.Model
{
	public class RuleSet : Node
	{
		private MiniYamlNode parentYamlNode;
		private List<MiniYamlNode> yamlNodes;
		private string yamlFilePath;

		public RuleSet(MiniYamlNode yamlNode) : base(NodeType.RuleSet)
		{
			this.parentYamlNode = yamlNode;
			if(this.yamlNodes != null)
			{
				this.yamlFilePath = yamlNode.Key;
				this.Name = yamlNode.Key;
				this.yamlNodes = MiniYaml.FromFile(this.yamlFilePath, false);
				foreach (var node in this.yamlNodes)
				{
					this.Children.Add(new Actor(node));
				}
			}
		}
	}
}

using System.Collections.Generic;
using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.Model
{
	public class WeaponSet : Node
	{
		private MiniYamlNode parentYamlNode;
		private List<MiniYamlNode> yamlNodes;
		private string yamlFilePath;
		private IPathResolver pathResolver;

		public WeaponSet(MiniYamlNode yamlNode, IPathResolver pathResolver) : base()
		{
			this.parentYamlNode = yamlNode;
			this.pathResolver = pathResolver;
			if(yamlNode != null)
			{
				var actualPath = pathResolver.ResolvePath(yamlNode.Key);
				this.yamlFilePath = actualPath;
				this.Name = yamlNode.Key;
				this.yamlNodes = MiniYaml.FromFile(actualPath, false);
				foreach (var node in this.yamlNodes)
				{
					if (!string.IsNullOrEmpty(node.Key))
						this.Children.Add(new Weapon(node));
				}
			}
		}

		public override void SaveState()
		{
			this.yamlNodes.WriteToFile(this.yamlFilePath);
		}
	}
}

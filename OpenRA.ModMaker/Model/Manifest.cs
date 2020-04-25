using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.Model
{
	public class Manifest : Node
	{
		private List<MiniYamlNode> yamlNodes;
		private readonly string yamlFilePath;
		
		public Manifest(Mod mod) : base()
		{
			this.yamlFilePath = Path.Combine(mod.ModsDirectoryPath, mod.ModId, "mod.yaml");
			this.yamlNodes = MiniYaml.FromFile(this.yamlFilePath, false);
			this.Children.Add(new Packages(this.yamlNodes.FirstOrDefault(x => x.Key == NodeNames.PackagesNodeName)?.Value));

			var pathResolver = new SimplePathResolver(this, mod.ModsDirectoryPath, mod.WorkingDirectoryPath);
			this.Children.Add(new RuleSetCollection(this.yamlNodes.FirstOrDefault(x => x.Key == NodeNames.RulesNodeName)?.Value, pathResolver));
			this.Children.Add(new WeaponSetCollection(this.yamlNodes.FirstOrDefault(x => x.Key == NodeNames.WeaponsNodeName)?.Value, pathResolver));
		}

		public override void SaveState()
		{
			base.SaveState();
			this.yamlNodes.WriteToFile(this.yamlFilePath);
		}
	}
}

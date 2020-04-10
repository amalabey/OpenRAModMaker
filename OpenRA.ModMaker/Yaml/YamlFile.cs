using System.Collections.Generic;
using OpenRA;

namespace OpenRA.ModMaker.Yaml
{
	public class YamlFile
	{
		private readonly string filePath;
		public List<MiniYamlNode> YamlNodes { get; set; }

		public YamlFile(string filePath)
		{
			this.filePath = filePath;
			this.YamlNodes = MiniYaml.FromFile(this.filePath, false);
		}

		public void Write()
		{
			this.YamlNodes.WriteToFile(filePath);
		}
	}
}

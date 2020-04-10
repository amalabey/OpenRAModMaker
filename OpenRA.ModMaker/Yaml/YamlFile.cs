using System.Collections.Generic;
using OpenRA;

namespace OpenRA.ModMaker.Yaml
{
	public class YamlFile
	{
		public List<MiniYamlNode> Read(string filePath)
		{
			return MiniYaml.FromFile(filePath, false);
		}

		public static void Write(List<MiniYamlNode> nodes, string filePath)
		{
			nodes.WriteToFile(filePath);
		}
	}
}

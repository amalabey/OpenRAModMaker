using System;
using System.Collections.Generic;
using OpenRA.ModMaker.Yaml;

namespace OpenRA.ModMaker.Model
{
	public class Manifest : Node
	{
		private List<MiniYamlNode> yaml;

		public override NodeType NodeType
		{
			get
			{
				return NodeType.Manifest;
			}
		}

		public Manifest(string path)
		{
			this.yaml = MiniYaml.FromFile(path, false);

		}
	}
}

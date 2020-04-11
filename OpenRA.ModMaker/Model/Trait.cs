using OpenRA.ModMaker.Extensions;

namespace OpenRA.ModMaker.Model
{
	public class Trait : Node
	{
		private MiniYamlNode yamlNode;

		public Trait(MiniYamlNode yamlNode) : base (NodeType.Trait)
		{
			this.yamlNode = yamlNode;
			if(this.yamlNode != null)
			{
				this.Name = yamlNode.Key;
				Attributes = yamlNode.Value.ToAttributeDictionary<string, object>(s => s, n => n.Value);
			}
		}
	}
}

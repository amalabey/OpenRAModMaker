using OpenRA.ModMaker.Extensions;

namespace OpenRA.ModMaker.Model
{
	public class Trait : Node
	{
		private MiniYamlNode yamlNode;

		public Trait(MiniYamlNode yamlNode) : base ()
		{
			this.yamlNode = yamlNode;
			if(this.yamlNode != null)
			{
				this.Name = yamlNode.Key;
				this.Value = yamlNode.Value?.Value;
				Attributes = yamlNode.Value.ToAttributeDictionary<object>(s => s, n => n.Value);
				yamlNode.Value.SyncFrom(Attributes);
			}
		}
	}
}

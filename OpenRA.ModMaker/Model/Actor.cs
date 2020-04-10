namespace OpenRA.ModMaker.Model
{
	public class Actor : Node
	{
		private MiniYamlNode yaml;

		public Actor(MiniYamlNode yaml) : base(NodeType.Actor)
		{
			this.yaml = yaml;
			if (yaml != null)
			{
				this.Name = yaml.Key;
				foreach (var node in yaml.Value.Nodes)
				{
					this.Children.Add(new Actor(node));
				}
			}
		}
	}
}

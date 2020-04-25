namespace OpenRA.ModMaker.Model
{
	public class Weapon : Node
	{
		private MiniYamlNode yaml;

		public Weapon(MiniYamlNode yaml) : base()
		{
			this.yaml = yaml;
			if (yaml != null)
			{
				this.Name = yaml.Key;
				foreach (var node in yaml.Value.Nodes)
				{
					if(!string.IsNullOrEmpty(node.Key))
						this.Children.Add(new Trait(node));
				}
			}
		}
	}
}

namespace OpenRA.ModMaker.Model
{
	public class RuleSetCollection : Node
	{
		private MiniYaml yaml;

		public RuleSetCollection(MiniYaml yaml) : base(NodeType.RuleSetCollection)
		{
			this.yaml = yaml;
			this.Name = "Rules";
			if(yaml != null)
			{
				foreach (var node in yaml.Nodes)
				{
					this.Children.Add(new RuleSet(node));
				}
			}
		}
	}
}

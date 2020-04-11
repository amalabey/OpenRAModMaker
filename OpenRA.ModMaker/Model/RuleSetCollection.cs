using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.Model
{
	public class RuleSetCollection : Node
	{
		private readonly MiniYaml yaml;
		private readonly IPathResolver pathResolver;

		public RuleSetCollection(MiniYaml yaml, IPathResolver pathResolver) : base(NodeType.RuleSetCollection)
		{
			this.yaml = yaml;
			this.pathResolver = pathResolver;
			this.Name = "Rules";
			if(yaml != null)
			{
				foreach (var node in yaml.Nodes)
				{
					if (!string.IsNullOrEmpty(node.Key))
						this.Children.Add(new RuleSet(node, pathResolver));
				}
			}
		}
	}
}

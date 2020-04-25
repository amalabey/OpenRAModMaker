using OpenRA.ModMaker.Services;

namespace OpenRA.ModMaker.Model
{
	public class WeaponSetCollection : Node
	{
		private readonly MiniYaml yaml;
		private readonly IPathResolver pathResolver;

		public WeaponSetCollection(MiniYaml yaml, IPathResolver pathResolver) : base()
		{
			this.yaml = yaml;
			this.pathResolver = pathResolver;
			this.Name = NodeNames.WeaponsNodeName;
			if(yaml != null)
			{
				foreach (var node in yaml.Nodes)
				{
					if (!string.IsNullOrEmpty(node.Key))
						this.Children.Add(new WeaponSet(node, pathResolver));
				}
			}
		}
	}
}

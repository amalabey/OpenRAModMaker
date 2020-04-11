using System.Linq;
using OpenRA.ModMaker.Extensions;

namespace OpenRA.ModMaker.Model
{
	public class Packages : Node
	{
		private MiniYaml yaml;

		public Packages(MiniYaml yaml):base()
		{
			Name = Constants.PackagesNodeName;
			this.yaml = yaml;
			if (yaml != null)
			{
				Attributes = yaml.ToAttributeDictionary<string, object>(s => s, n => n.Value);
			}
		}
	}
}

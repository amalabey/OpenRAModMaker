using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRA.ModMaker.Primitives;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Extensions
{
	public static class MiniYamlExtensions
	{
		public static AttributeDictionary<string, T> ToAttributeDictionary<T>(this MiniYaml yml,
			Func<string, string> keySelector, Func<MiniYaml, T> elementSelector)
		{
			var ret = new AttributeDictionary<string, T>();
			foreach (var y in yml.Nodes)
			{
				var key = keySelector(y.Key);
				if (!String.IsNullOrEmpty(key))
				{
					var element = elementSelector(y.Value);
					try
					{
						ret.Add(key, element);
					}
					catch (ArgumentException ex)
					{
						throw new InvalidDataException("Duplicate key '{0}' in {1}".F(y.Key, y.Location), ex);
					}
				}
			}

			return ret;
		}

		public static void SyncFrom(this MiniYaml yml, AttributeDictionary<string,object> dict)
		{
			dict.OnAdd += (k, v) => yml.Nodes.Add(new MiniYamlNode(k, new MiniYaml((string)v)));
			dict.OnRemove += (k) => yml.Nodes.Remove(yml.Nodes.FirstOrDefault(x => x.Key == k));
			dict.OnSet += (k, v) => yml.Nodes.FirstOrDefault(x => x.Key == k).Value.Value = (string)v;
			dict.OnClear += () => yml.Nodes.Clear();
		}
	}
}

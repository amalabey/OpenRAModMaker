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
		public static AttributeDictionary<TKey, TElement> ToAttributeDictionary<TKey, TElement>(this MiniYaml yml,
			Func<string, TKey> keySelector, Func<MiniYaml, TElement> elementSelector)
		{
			var ret = new AttributeDictionary<TKey, TElement>();
			foreach (var y in yml.Nodes)
			{
				var key = keySelector(y.Key);
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

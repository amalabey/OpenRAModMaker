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
	}
}

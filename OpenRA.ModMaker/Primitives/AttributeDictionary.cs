using System.Collections.Generic;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Primitives
{
	public class AttributeDictionary<TKey, TValue> : ObservableDictionary<TKey, TValue>
	{
		public AttributeDictionary()
		{
			innerDict = new Dictionary<TKey, TValue>();
		}
	}
}

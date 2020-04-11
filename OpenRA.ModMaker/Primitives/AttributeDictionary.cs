using System;
using System.Collections;
using System.Collections.Generic;
using OpenRA.Primitives;

namespace OpenRA.ModMaker.Primitives
{
	public class AttributeDictionary<TKey, TValue> : IDictionary<TKey, TValue>
	{
		protected IDictionary<TKey, TValue> innerDict;
		public event Action<TKey, TValue> OnAdd = (k, v) => { };
		public event Action<TKey> OnRemove = (k) => { };
		public event Action<KeyValuePair<TKey, TValue>[], int> OnCopyTo = (kv, i) => { };
		public event Action<TKey, TValue> OnSet = (k, v) => { };
		public event Action OnClear = () => { };

		protected void FireOnRefresh()
		{
			OnClear();
		}

		public AttributeDictionary() 
		{
			innerDict = new Dictionary<TKey, TValue>();
		}

		public TValue this[TKey key]
		{
			get
			{
				return innerDict[key];
			}
			set
			{
				innerDict[key] = value;
				OnSet(key, value);
			}
		}

		public void Add(TKey key, TValue value)
		{
			innerDict.Add(key, value);
			OnAdd(key, value);
		}

		public bool Remove(TKey key)
		{
			var found = innerDict.Remove(key);
			if (found)
				OnRemove(key);
			return found;
		}

		public bool ContainsKey(TKey key)
		{
			return innerDict.ContainsKey(key);
		}

		public ICollection<TKey> Keys { get { return innerDict.Keys; } }
		public ICollection<TValue> Values { get { return innerDict.Values; } }

		public bool TryGetValue(TKey key, out TValue value)
		{
			return innerDict.TryGetValue(key, out value);
		}

		public void Clear()
		{
			innerDict.Clear();
			OnClear();
		}

		public int Count
		{
			get { return innerDict.Count; }
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
			OnAdd(item.Key, item.Value);
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return innerDict.Contains(item);
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			innerDict.CopyTo(array, arrayIndex);
			OnCopyTo(array, arrayIndex);
		}

		public bool IsReadOnly
		{
			get { return innerDict.IsReadOnly; }
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			OnRemove(item.Key);
			return Remove(item.Key);
		}

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return innerDict.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return innerDict.GetEnumerator();
		}

		public IEnumerable ObservedItems
		{
			get { return innerDict.Keys; }
		}
	}
}

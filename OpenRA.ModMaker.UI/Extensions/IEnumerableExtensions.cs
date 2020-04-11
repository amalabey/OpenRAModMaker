using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenRA.ModMaker.UI.Extensions
{
	public static class IEnumerableExtensions
	{
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> col)
		{
			return new ObservableCollection<T>(col);
		}
	}
}

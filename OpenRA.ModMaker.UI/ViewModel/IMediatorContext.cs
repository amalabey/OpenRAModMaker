using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenRA.ModMaker.UI.ViewModel
{
	public delegate void AttributeAddedEventHandler(TreeViewNode node);

	public interface IMediatorContext
	{
		event AttributeAddedEventHandler AttributeAdded;

		void NotifyAttributeAdded(TreeViewNode node);
	}
}

using System;

namespace OpenRA.ModMaker.UI.Services
{
	public interface IUIContext
	{
		void Invoke(Action action);
		void BeginInvoke(Action action);
	}
}

using System;
using System.Threading;
using System.Windows.Threading;

namespace OpenRA.ModMaker.UI.Services
{
	public class WpfUIContext : IUIContext
	{
		private readonly Dispatcher dispatcher;

		public bool IsSynchronized
		{
			get
			{
				return dispatcher.Thread == Thread.CurrentThread;
			}
		}

		public WpfUIContext() : this(Dispatcher.CurrentDispatcher)
		{
		}

		public WpfUIContext(Dispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
		}

		public void BeginInvoke(Action action)
		{
			dispatcher.Invoke(action);
		}

		public void Invoke(Action action)
		{
			dispatcher.BeginInvoke(action);
		}
	}
}

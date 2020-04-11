using System;
using System.Windows.Input;

namespace OpenRA.ModMaker.UI.ViewModel.Base
{
	public class RelayCommand<T> : ICommand
	{
		private Action<T> action;
		private Predicate<T> canExecuteEvaluator;

		public RelayCommand(Action<T> action, Predicate<T> canExecuteEvaluator)
		{
			this.action = action;
			this.canExecuteEvaluator = canExecuteEvaluator;
		}

		public event EventHandler CanExecuteChanged = (sender, e) => { };

		public bool CanExecute(object parameter) => canExecuteEvaluator((T)parameter);
		public void Execute(object parameter) => action((T)parameter);
	}
}

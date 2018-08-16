using System;
using System.Windows.Input;

namespace ColorViewer
{
	internal sealed class Command : ICommand
	{
		private Action add;
		private Func<bool> canExecuteMethod;

		public Command(Action add) :
			this(add, () => true)
		{
		}

		public event EventHandler CanExecuteChanged;

		public Command(Action add, Func<bool> canExecuteMethod)
		{
			this.add = add;
			this.canExecuteMethod = canExecuteMethod;
		}

		bool ICommand.CanExecute(object parametr)
		{
			return CanExecute();
		}

		public bool CanExecute()
		{
			return canExecuteMethod();
		}

		public void Execute(object parameter)
		{
			add();
		}

		public void RaiseCanExecute()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
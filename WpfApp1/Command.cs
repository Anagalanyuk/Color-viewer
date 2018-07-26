using System;
using System.Windows.Input;

namespace ColorViewer
{
	internal sealed class Command : ICommand
	{
		public event EventHandler CanExecuteChanged;
		private Func<bool> canExecuteMethod;
		private Action add;
		private Func<bool> canAdd;
		private ICommand delete;

		public Command(Action add) :
			this(add, () => true)
		{
		}

		public Command(Action add, Func<bool> canExecuteMethod)
		{
			this.add = add;
			this.canExecuteMethod = canExecuteMethod;
		}

		public void RaiseCanExecute()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public Command(ICommand deleteCommand, Func<bool> canAdd)
		{
			this.canAdd = canAdd;
		}

		public Command(ICommand delete)
		{
			this.delete = delete;
		}

		public bool CanExecute()
		{
			return canExecuteMethod();
		}

		bool ICommand.CanExecute(object parametr)
		{
			return CanExecute();
		}

		public void Execute(object parameter)
		{
			add();
		}
	}
}
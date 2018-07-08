using System;
using System.Windows.Input;

namespace WpfApp1
{
	internal sealed class Command : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private Func<bool> canExecuteMethod;
		private Action add;
		private ICommand deleteCommand;
		private Func<bool> canAdd;

		public Command(Action add) :
			this(add, () => true)
		{
		}

		public Command(Action add, Func<bool> canExecuteMethod)
		{
			this.add = add;
			this.canExecuteMethod = canExecuteMethod;
		}

		public Command(ICommand deleteCommand, Func<bool> canAdd)
		{
			this.deleteCommand = deleteCommand;
			this.canAdd = canAdd;
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

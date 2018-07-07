using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
	internal sealed class DelegateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private Func<bool> canExecuteMethod;
		private Action add;

		public DelegateCommand(Action add, Func<bool> canExecuteMethod)
		{
			this.add = add;
			this.canExecuteMethod = canExecuteMethod;
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

using System.Collections.Generic;
using System.Windows.Input;

namespace ColorViewer
{
	internal sealed class UserColor
	{
		private Command addCommand;
		private string userColor = string.Empty;
		private Command deleteComand;
		private ICollection<UserColor> colors;

		public ICommand DeleteCommand => deleteComand;
		public string Color => userColor;

		public UserColor(string color, ICollection<UserColor> colors, Command addCommand)
		{
			this.addCommand = addCommand; 
			userColor = color;
			deleteComand = new Command(Delete);
			this.colors = colors;
		}

		public void Delete()
		{
			colors.Remove(this);
			addCommand.RaiseCanExecute();
		}

	}
}
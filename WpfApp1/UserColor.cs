using System.Collections.Generic;
using System.Windows.Input;

namespace ColorViewer
{
	internal sealed class UserColor
	{
		private readonly string userColor = string.Empty;
		private Command addCommand;
		private ICollection<UserColor> colors;
		private Command deleteComand;

		public string Color => userColor;

		public ICommand DeleteCommand => deleteComand;

		public void Delete()
		{
			colors.Remove(this);
			addCommand.RaiseCanExecute();
		}

		public UserColor(string color, ICollection<UserColor> colors, Command addCommand)
		{
			this.addCommand = addCommand;
			userColor = color;
			deleteComand = new Command(Delete);
			this.colors = colors;
		}
	}
}
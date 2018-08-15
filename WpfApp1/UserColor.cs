using System.Collections.Generic;
using System.Windows.Input;

namespace ColorViewer
{
	internal sealed class UserColor
	{
		private readonly string userColor = string.Empty;
		private readonly ICommand deleteComand;
		private ICommand addCommand;
		private ICollection<UserColor> colors;

		public UserColor(string color, ICollection<UserColor> colors, ICommand addCommand)
		{
			this.addCommand = addCommand;
			userColor = color;
			deleteComand = new Command(Delete);
			this.colors = colors;
		}

		public string Color => userColor;

		public ICommand DeleteCommand => deleteComand;

		public void Delete()
		{
			colors.Remove(this);
		}
	}
}
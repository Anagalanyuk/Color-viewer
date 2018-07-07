namespace ColorViewer
{
	internal sealed class UserColor
	{
		private string userColor = string.Empty;

		public UserColor(string color)
		{
			userColor = color;
		}

		public string Color => userColor; 
	}
}
namespace Mvvm
{
	internal sealed class UserColor
	{
		private readonly double alfa;
		private readonly double blue;
		private readonly double green;
		private readonly double red;

		public UserColor(byte alfa, byte blue, byte green, byte red)
		{
			this.alfa = alfa;
			this.blue = blue;
			this.green = green;
			this.red = red;
		}

		public double Alfa=>alfa;

		public double Blue => blue;

		public double Green => green;

		public double Red => red;
	}
}
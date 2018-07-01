using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
	internal sealed class UserColor
	{
		private readonly byte alfa;
		private readonly byte red;
		private readonly byte green;
		private readonly byte blue;

		public UserColor(byte alfa, byte red, byte green, byte blue)
		{
			this.alfa = alfa;
			this.red = red;
			this.green = green;
			this.blue = blue;
		}

		public byte Alfa=>alfa;

		public byte Red => red;

		public byte Green => green;

		public byte Blue => blue;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace Mvvm
{
	internal class viewModel : INotifyPropertyChanged
	{
		private double alfa;
		private double blue;
		private string color = string.Empty;
		private double green;
		private double red;

		public event PropertyChangedEventHandler PropertyChanged;

		public viewModel()
		{
		}

		public double Alfa
		{
			get => alfa;
			set
			{
				alfa = value;
				ChangeColor();
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Alfa)));
			}
		}

		public double Blue
		{
			get => blue;
			set
			{
				blue = value;
				ChangeColor();
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Blue)));
			}
		}

		public string Color
		{
			get => color;
		}

		public double Green
		{
			get => green;
			set
			{
				green = value;
				ChangeColor();
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Green)));
			}
		}

		public double Red
		{
			get => red;
			set
			{
				red = value;
				ChangeColor();
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(red)));
			}
		}

		public void ChangeColor()
		{
			color = "#";
			if(alfa < 16)
			{
				color += "0";
				color += Convert.ToString((int)alfa, 16);
			}
			else
			{
				color += Convert.ToString((int)alfa, 16);

			}
			if (red < 16)
			{
				color += "0";
				color += Convert.ToString((int)red, 16);
			}
			else
			{
				color += Convert.ToString((int)red, 16);
			}
			if(green < 16)
			{
				color += "0";
				color += Convert.ToString((int)green, 16);
			}
			else
			{
				color += Convert.ToString((int)green, 16);
			}
			if(blue < 16)
			{
				color += "0";
				color += Convert.ToString((int)blue, 16);
			}
			else
			{
				color += Convert.ToString((int)blue, 16);
			}
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(Color)));
		}
	}
}
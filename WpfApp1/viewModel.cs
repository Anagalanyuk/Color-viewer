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
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Alfa)));
			}
		}

		public double Blue
		{
			get => blue;
			set
			{
				blue = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Blue)));
			}
		}

		public double Green
		{
			get => green;
			set
			{
				green = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(Green)));
			}
		}

		public double Red
		{
			get => red;
			set
			{
				red = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(red)));
			}
		}
	}
}
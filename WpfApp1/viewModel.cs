using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1;

namespace ColorViewer
{
	internal class ViewModel : INotifyPropertyChanged
	{
		private readonly ICollection<UserColor> colors = new ObservableCollection<UserColor>();
		private readonly ICommand addCommand;

		private double alfa;
		private double blue;
		private string color = string.Empty;
		private double green;
		private bool isAdd = true;
		private bool onAlfa = true;
		private bool onBlue = true;
		private bool onGreen = true;
		private bool onRed = true;
		private double red;


		public event PropertyChangedEventHandler PropertyChanged;

		public ViewModel()
		{
			addCommand = new DelegateCommand(Add, canAdd);
		}

		public ICommand AddCommand => addCommand;

		public void Add()
		{
			colors.Add(new UserColor(color));
		}

		public bool canAdd()
		{
			foreach(UserColor userColor in colors)
			{
				if(color == userColor.Color)
				{
					isAdd = false;
					break;
				}
				else
				{
					isAdd = true;
				}
			}
			return isAdd;
		}

		public IEnumerable<UserColor> Colors => colors;

		public double Alfa
		{
			get => alfa;
			set
			{
				alfa = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Alfa)));
			}
		}

		public double Blue
		{
			get => blue;
			set
			{
				blue = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Blue)));
			}
		}

		public string Color
		{
			get => color;
			set
			{
				color = ChangeColor();
			}
		}

		public double Green
		{
			get => green;
			set
			{
				green = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Green)));
			}
		}

		public bool StateAlfa
		{
			get => onAlfa;
			set
			{
				onAlfa = value;
				OnPropertyChange(new PropertyChangedEventArgs(nameof(StateAlfa)));
			}
		}

		public bool StateBlue
		{
			get => onBlue;
			set
			{
				onBlue = value;
				OnPropertyChange(new PropertyChangedEventArgs(nameof(StateBlue)));
			}
		}

		public bool StateGreen
		{
			get => onGreen;
			set
			{
				onGreen = value;
				OnPropertyChange(new PropertyChangedEventArgs(nameof(StateGreen)));
			}
		}

		public bool StateRed
		{
			get => onRed;
			set
			{
				onRed = value;
				OnPropertyChange(new PropertyChangedEventArgs(nameof(StateRed)));
			}
		}

		public double Red
		{
			get => red;
			set
			{
				red = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Red)));
			}
		}

		public string ChangeColor()
		{
			color = "#";
			if (alfa < 16)
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
			if (green < 16)
			{
				color += "0";
				color += Convert.ToString((int)green, 16);
			}
			else
			{
				color += Convert.ToString((int)green, 16);
			}
			if (blue < 16)
			{
				color += "0";
				color += Convert.ToString((int)blue, 16);
			}
			else
			{
				color += Convert.ToString((int)blue, 16);
			}
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(Color)));
			return color = color.ToUpper();
		}

		public void OnPropertyChange(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
}
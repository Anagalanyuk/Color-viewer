using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ColorViewer
{
	internal class ViewModel : INotifyPropertyChanged
	{
		private readonly Command addCommand;
		private readonly ICollection<UserColor> colors = new ObservableCollection<UserColor>();

		private double alpha = 255;
		private double blue;
		private string color = "#FE000000";
		private double green;
		private bool isAdd = true;
		private bool onAlpha = true;
		private bool onBlue = true;
		private bool onGreen = true;
		private bool onRed = true;
		private double red;

		public event PropertyChangedEventHandler PropertyChanged;

		public ViewModel()
		{
			addCommand = new Command(Add, CanAdd);
		}

		public ICommand AddCommand => addCommand;

		public IEnumerable<UserColor> Colors => colors;

		public double Alpha
		{
			get => alpha;
			set
			{
				alpha = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Alpha)));
				addCommand.RaiseCanExecute();
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
				addCommand.RaiseCanExecute();
			}
		}

		public string Color
		{
			get => color;
			private set { color = ChangeColor(); }
		}

		public double Green
		{
			get => green;
			set
			{
				green = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Green)));
				addCommand.RaiseCanExecute();
			}
		}

		public bool StateAlpha
		{
			get => onAlpha;
			set
			{
				onAlpha = value;
				OnPropertyChange(new PropertyChangedEventArgs(nameof(StateAlpha)));
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
				addCommand.RaiseCanExecute();
			}
		}

		public void Add()
		{
			colors.Add(new UserColor(color, colors, addCommand));
			addCommand.RaiseCanExecute();
		}

		public bool CanAdd()
		{
			isAdd = true;
			foreach (UserColor userColor in colors)
			{
				if (color == userColor.Color)
				{
					isAdd = false;
					break;
				}
			}
			return isAdd;
		}

		public string ChangeColor()
		{
			color = "#";
			if (alpha < 16)
			{
				color += "0";
				color += Convert.ToString((int)alpha, 16);
			}
			else
			{
				color += Convert.ToString((int)alpha, 16);

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
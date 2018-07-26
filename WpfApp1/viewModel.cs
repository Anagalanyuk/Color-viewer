using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ColorViewer
{
	internal class ViewModel : INotifyPropertyChanged
	{
		private readonly ICollection<UserColor> colors = new ObservableCollection<UserColor>();
		private readonly Command addCommand;

		private double alfa = 255;
		private double blue;
		private string color = "#FE000000";
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
			addCommand = new Command(Add, canAdd);
		}

		public ICommand AddCommand => addCommand;

		public IEnumerable<UserColor> Colors => colors;

		public bool OnButtonAdd
		{
			get
			{
				isAdd = true;
				foreach (UserColor indexColors in colors)
				{
					if (color.Equals(indexColors.Color))
					{
						isAdd = false;
						break;
					}
				}
				return isAdd;
			}
		}

		public void Add()
		{
			colors.Add(new UserColor(color, colors, addCommand));
			addCommand.RaiseCanExecute();
		}

		public bool canAdd()
		{
			if (colors.Count == 0)
			{
				isAdd = true;
			}
			foreach (UserColor userColor in colors)
			{
				if (color == userColor.Color)
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

		public double Alfa
		{
			get => alfa;
			set
			{
				alfa = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Alfa)));
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
				addCommand.RaiseCanExecute();
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
				addCommand.RaiseCanExecute();
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
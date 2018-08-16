using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace ColorViewer
{
	internal class ViewModel : INotifyPropertyChanged
	{
		private const string colorCode = "#FF000000";
		private const int notation = 16;
		private const int singleDigit = 16;
		private const double transparency = 255;

		private readonly Command addCommand;
		private readonly ObservableCollection<UserColor> colors = new ObservableCollection<UserColor>();

		private double alpha;
		private double blue;
		private string colorImage;
		private double green;
		private bool isAdd = true;
		private bool onAlpha = true;
		private bool onBlue = true;
		private bool onGreen = true;
		private bool onRed = true;
		private double red;

		public ViewModel()
		{
			addCommand = new Command(Add, CanAdd);
			alpha = transparency;
			colorImage = colorCode;
			colors.CollectionChanged += IsAdd;
		}

		public ICommand AddCommand => addCommand;

		public double Alpha
		{
			get => alpha;
			set
			{
				if (alpha != value)
				{
					alpha = value;
					ChangeColor();
					OnPropertyChange(new PropertyChangedEventArgs(nameof(Alpha)));
					addCommand.RaiseCanExecute();
				}
			}
		}

		public double Blue
		{
			get => blue;
			set
			{
				if (blue != value)
				{
					blue = value;
					ChangeColor();
					OnPropertyChange(new PropertyChangedEventArgs(nameof(Blue)));
					addCommand.RaiseCanExecute();
				}
			}
		}

		public string ColorImage
		{
			get => colorImage;
			private set
			{
				if (ColorImage != value)
				{
					colorImage = value;
					OnPropertyChange(new PropertyChangedEventArgs(nameof(ColorImage)));
				}
			}
		}

		public IEnumerable<UserColor> Colors => colors;

		public double Green
		{
			get => green;
			set
			{
				if (green != value)
				{
					green = value;
					ChangeColor();
					OnPropertyChange(new PropertyChangedEventArgs(nameof(Green)));
					addCommand.RaiseCanExecute();
				}
			}
		}

		public double Red
		{
			get => red;
			set
			{
				if (red != value)
				{
					red = value;
					ChangeColor();
					OnPropertyChange(new PropertyChangedEventArgs(nameof(Red)));
					addCommand.RaiseCanExecute();
				}
			}
		}

		public bool StateAlpha
		{
			get => onAlpha;
			set
			{
				if (onAlpha != value)
				{
					onAlpha = value;
					OnPropertyChange(new PropertyChangedEventArgs(nameof(StateAlpha)));
				}
			}
		}

		public bool StateBlue
		{
			get => onBlue;
			set
			{
				if (onBlue != value)
				{
					onBlue = value;
					OnPropertyChange(new PropertyChangedEventArgs(nameof(StateBlue)));
				}
			}
		}

		public bool StateGreen
		{
			get => onGreen;
			set
			{
				if (onGreen != value)
				{
					onGreen = value;
					OnPropertyChange(new PropertyChangedEventArgs(nameof(StateGreen)));
				}
			}
		}

		public bool StateRed
		{
			get => onRed;
			set
			{
				if (onRed != value)
				{
					onRed = value;
					OnPropertyChange(new PropertyChangedEventArgs(nameof(StateRed)));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void Add()
		{
			colors.Add(new UserColor(colorImage, colors, addCommand));
		}

		public bool CanAdd()
		{
			isAdd = true;
			foreach (UserColor userColor in colors)
			{
				if (colorImage == userColor.Color)
				{
					isAdd = false;
					break;
				}
			}
			return isAdd;
		}

		public void ChangeColor()
		{
			string colorCod = string.Empty;
			colorCod = "#";
			if (alpha < singleDigit)
			{
				colorCod += "0";
				colorCod += Convert.ToString((int)alpha, notation);
			}
			else
			{
				colorCod += Convert.ToString((int)alpha, notation);

			}
			if (red < singleDigit)
			{
				colorCod += "0";
				colorCod += Convert.ToString((int)red, notation);
			}
			else
			{
				colorCod += Convert.ToString((int)red, notation);
			}
			if (green < singleDigit)
			{
				colorCod += "0";
				colorCod += Convert.ToString((int)green, notation);
			}
			else
			{
				colorCod += Convert.ToString((int)green, notation);
			}
			if (blue < singleDigit)
			{
				colorCod += "0";
				colorCod += Convert.ToString((int)blue, notation);
			}
			else
			{
				colorCod += Convert.ToString((int)blue, notation);
			}
			colorCod = colorCod.ToUpper();
			ColorImage = colorCod;
		}

		private void IsAdd(object sender, NotifyCollectionChangedEventArgs e)
		{
			addCommand.RaiseCanExecute();
		}

		public void OnPropertyChange(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
}
﻿using System;
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
		private readonly int notation = 16;
		private readonly int singleDigit = 16;
		private readonly double transparency = 255;
		string colorImageCod = "#FE000000";

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

		public event PropertyChangedEventHandler PropertyChanged;

		public ViewModel()
		{
			addCommand = new Command(Add, CanAdd);
			alpha = transparency;
			colorImage = colorImageCod;
		}

		public ICommand AddCommand => addCommand;

		public IEnumerable<UserColor> Colors => colors;

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
				blue = value;
				ChangeColor();
				OnPropertyChange(new PropertyChangedEventArgs(nameof(Blue)));
				addCommand.RaiseCanExecute();
			}
		}

		public string Color
		{
			get => colorImage;
			private set { colorImage = ChangeColor(); }

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
			colors.Add(new UserColor(colorImage, colors, addCommand));
			addCommand.RaiseCanExecute();
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

		public string ChangeColor()
		{
			colorImage = "#";
			if (alpha < singleDigit)
			{
				colorImage += "0";
				colorImage += Convert.ToString((int)alpha, notation);
			}
			else
			{
				colorImage += Convert.ToString((int)alpha, notation);

			}
			if (red < singleDigit)
			{
				colorImage += "0";
				colorImage += Convert.ToString((int)red, notation);
			}
			else
			{
				colorImage += Convert.ToString((int)red, notation);
			}
			if (green < singleDigit)
			{
				colorImage += "0";
				colorImage += Convert.ToString((int)green, notation);
			}
			else
			{
				colorImage += Convert.ToString((int)green, notation);
			}
			if (blue < singleDigit)
			{
				colorImage += "0";
				colorImage += Convert.ToString((int)blue, notation);
			}
			else
			{
				colorImage += Convert.ToString((int)blue, notation);
			}
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(Color)));
			colorImage = colorImage.ToUpper();
			return colorImage;
		}

		public void OnPropertyChange(PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(this, e);
		}
	}
}
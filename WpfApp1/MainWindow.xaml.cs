﻿using System.Windows;

namespace ColorViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal partial class MainWindow : Window
	{
		public MainWindow(ViewModel mainView)
		{
			InitializeComponent();

			DataContext = mainView;
		}
	}
}
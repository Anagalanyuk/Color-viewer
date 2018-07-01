using System.Windows;
using System.Windows.Media;

namespace Mvvm
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal partial class MainWindow : Window
	{
		public MainWindow(viewModel model)
		{
			InitializeComponent();

			DataContext = model;
		}
	}
}

using System.Windows;

namespace ColorViewer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	internal partial class MainWindow : Window
	{
		internal MainWindow(ViewModel viewModel)
		{
			InitializeComponent();

			DataContext = viewModel;
		}
	}
}
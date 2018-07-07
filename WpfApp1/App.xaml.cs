using System.Windows;

namespace ColorViewer
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	internal partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ViewModel viewModel = new ViewModel();

			var mainWindow = new MainWindow(viewModel);

			mainWindow.Show();
		}
	}
}
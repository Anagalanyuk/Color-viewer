using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Mvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal  partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            viewModel viewModel = new viewModel();

            var mainWindow = new MainWindow(viewModel);

            mainWindow.Show();
        }
    }
}
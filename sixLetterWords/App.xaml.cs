using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using wpf.viewmodels;
using wpf.views;

namespace sixLetterWords
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var view = new MainWindow();
            var vm = new MainWindowViewModel(view);
            view.DataContext = vm;
            view.Show();
        }
    }
}

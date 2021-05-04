using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows;

namespace AbschlussprojektIHK
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }
        protected void OnStartup(object sender, StartupEventArgs e)
        {
            if (File.Exists("User.json"))
            {
                UserFormularWindow startWindow = new UserFormularWindow();
                startWindow.ShowDialog();
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }

        }
        private void OnExit(object sender, ExitEventArgs e)
        {

        }
    }
}

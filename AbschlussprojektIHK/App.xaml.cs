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
        private IHost _host;

        public App()
        {
            _host = new HostBuilder().Build();
        }
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected void OnStartup(object sender, StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile(@"appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
            //check if user have filled formular
            User user = new User();
            user = JSON.DeserializeUser();
            if (user.Firstname == "")
            {
                var startWindow = ServiceProvider.GetRequiredService<StartWindow>();
                startWindow.Show();
            }
            else
            {
                var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
                mainWindow.Show();
            }

        }

        private void ConfigureServices(IServiceCollection services)
        {
            // ...

            services.AddTransient(typeof(MainWindow));
        }
    }
}

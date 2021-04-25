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
        private readonly Appsettings appsettings;
        private readonly User user;
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        public App()
        {
            _host = new HostBuilder()
                        .ConfigureAppConfiguration((context, configurationBuilder) =>
                        {
                            configurationBuilder.SetBasePath(context.HostingEnvironment.ContentRootPath);
                            configurationBuilder.AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true);
                            configurationBuilder.AddJsonFile("User.json", optional: false, reloadOnChange: true);
                        })
                        .ConfigureServices((context, services) =>
                        {
                            services.Configure<Appsettings>(context.Configuration);
                            services.Configure<User>(context.Configuration);

                            services.AddSingleton<IUser, User>();
                            services.AddSingleton<IAppsettings, Appsettings>();

                            services.AddSingleton<StartWindow>();
                            services.AddSingleton<MainWindow>();
                            services.AddSingleton<SecurityQuestionReset>();
                        })
                        .Build();
        }


        protected void OnStartup(object sender, StartupEventArgs e)
        {
            if (File.Exists("User.json")) //close Startwindow when User.json already exist at start
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }
            else
            {
                StartWindow startWindow = new StartWindow();
                startWindow.ShowDialog();
            }
 
            //var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            //mainWindow.Show();

        }
        private async void OnExit(object sender, ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}

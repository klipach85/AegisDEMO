using Microsoft.Extensions.DependencyInjection;
using Northwind.Services;
using System;
using System.Windows;

namespace Northwind
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ICustomerServiceClient, CustomerServiceClient>(config =>
            {
                config.BaseAddress = new Uri("http://localhost:59385"); 
            });

            services.AddSingleton<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}

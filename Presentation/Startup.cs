using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Presentation
{
    public partial class App
    {
        private readonly IConfiguration _configuration;

        public App()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceProvider = ConfigureServices();
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<MilitaryProjectDbContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString("BloggingDatabase")));

            services.AddTransient<MainWindow>();

            return services.BuildServiceProvider();
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoIntegrador.Infrastructure;

namespace ProjetoIntegrador
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var pathToContentRoot = Directory.GetCurrentDirectory();
            var fileToLoad = args != null && args.Length > 0 ? args[0] : string.Empty;
            var host = new HostBuilder()
              .UseContentRoot(pathToContentRoot)
              .ConfigureAppConfiguration((hostContext, configApp) =>
              {
                  configApp.AddJsonFile($"appsettings.json", optional: true);
                  configApp.AddCommandLine(args);
              })
              .ConfigureServices((hostContext, services) =>
              {
                  var settings = hostContext.Configuration.GetSection("Settings");
                  services.Configure<Settings>(settings);
                  services.AddScoped<AuthenticationForm>();
              }).Build();

            using var servicesScope = host.Services.CreateScope();
            var services = servicesScope.ServiceProvider;
            var autenticationViewer = services.GetService<AuthenticationForm>();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.Run(autenticationViewer);
        }
    }
}
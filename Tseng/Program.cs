using Tseng.Extensions;
using Tseng.Startup;

namespace Tseng
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Task.Run(StartWebHost);
            ApplicationConfiguration.Initialize();
            Application.Run(new HostWindow());
            
        }

        private static void StartWebHost()
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions());
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.RegisterServices();

            var app = builder.Build();
            app.Urls.Add("http://localhost:7777");

            app.UseStaticFiles();
            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
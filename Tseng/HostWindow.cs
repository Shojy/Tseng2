using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Tseng.Startup;

namespace Tseng
{
    public partial class HostWindow : Form
    {
        public HostWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();
            services.RegisterServices();

            BlazorView.HostPage = "wwwroot\\app.html";
            BlazorView.Services = services.BuildServiceProvider();
            BlazorView.RootComponents.Add<App>("#app");

            BlazorView.SetDefaultBackgroundColor(Color.Transparent);
        }
    }
}
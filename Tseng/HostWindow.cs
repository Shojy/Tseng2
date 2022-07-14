using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace Tseng
{
    public partial class HostWindow : Form
    {
        public HostWindow()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddWindowsFormsBlazorWebView();

            BlazorView.HostPage = "wwwroot\\index.html";
            BlazorView.Services = services.BuildServiceProvider();
            BlazorView.RootComponents.Add<App>("#app");
            
            this.BackColor = Color.FromArgb(255, 128, 0);
            this.TransparencyKey = Color.FromArgb(255, 128, 0);

            BlazorView.SetDefaultBackgroundColor(Color.Transparent);
        }
    }
}
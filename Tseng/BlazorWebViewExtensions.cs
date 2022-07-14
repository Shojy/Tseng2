using System.Reflection;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Web.WebView2.WinForms;

namespace Tseng;

public static class BlazorWebViewExtensions
{
    public static void SetDefaultBackgroundColor(this BlazorWebView view, Color color)
    {
        var blweb = (WebView2)typeof(BlazorWebView)
            .GetField("_webview", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(view);

        blweb.DefaultBackgroundColor = color;
    }
}
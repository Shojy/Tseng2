using System.Reflection;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Web.WebView2.WinForms;

namespace Tseng;

public static class BlazorWebViewExtensions
{
    public static void SetDefaultBackgroundColor(this BlazorWebView view, Color color)
    {
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        var blweb = (WebView2)typeof(BlazorWebView)
            .GetField("_webview", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(view)!;
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields

        blweb.DefaultBackgroundColor = color;
    }
}
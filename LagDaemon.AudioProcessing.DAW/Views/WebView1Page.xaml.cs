using LagDaemon.AudioProcessing.DAW.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace LagDaemon.AudioProcessing.DAW.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class WebView1Page : Page
{
    public WebView1ViewModel ViewModel
    {
        get;
    }

    public WebView1Page()
    {
        ViewModel = App.GetService<WebView1ViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}

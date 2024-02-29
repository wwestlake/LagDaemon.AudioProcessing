using LagDaemon.AudioProcessing.DAW.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace LagDaemon.AudioProcessing.DAW.Views;

// To learn more about WebView2, see https://docs.microsoft.com/microsoft-edge/webview2/.
public sealed partial class WebView3Page : Page
{
    public WebView3ViewModel ViewModel
    {
        get;
    }

    public WebView3Page()
    {
        ViewModel = App.GetService<WebView3ViewModel>();
        InitializeComponent();

        ViewModel.WebViewService.Initialize(WebView);
    }
}

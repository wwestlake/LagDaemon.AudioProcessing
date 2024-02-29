using LagDaemon.AudioProcessing.DAW.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace LagDaemon.AudioProcessing.DAW.Views;

public sealed partial class ContentGridPage : Page
{
    public ContentGridViewModel ViewModel
    {
        get;
    }

    public ContentGridPage()
    {
        ViewModel = App.GetService<ContentGridViewModel>();
        InitializeComponent();
    }
}

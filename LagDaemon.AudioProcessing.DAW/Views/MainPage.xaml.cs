using LagDaemon.AudioProcessing.DAW.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace LagDaemon.AudioProcessing.DAW.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}

using System.ComponentModel;

namespace LagDaemon.AudioProcessing.UI.ViewModels
{
    public interface IViewModelBase
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}
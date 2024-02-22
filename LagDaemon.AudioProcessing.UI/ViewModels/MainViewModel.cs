using LagDaemon.AudioProcessing.Api.Models;
using LagDaemon.AudioProcessing.Api.Services;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LagDaemon.AudioProcessing.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        public ICommand NewCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }

        private bool _isNewEnabled = false;
        public bool IsNewEnabled
        {
            get => _isNewEnabled;
            set { _isNewEnabled = value; OnPropertyChanged(); }
        }

        private bool _isOpenEnabled = false;
        public bool IsOpenEnabled
        {
            get => _isOpenEnabled;
            set { _isOpenEnabled = value; OnPropertyChanged(); }
        }

        private bool _isSaveEnabled = false;
        public bool IsSaveEnabled
        {
            get => _isSaveEnabled;
            set { _isSaveEnabled = value; OnPropertyChanged(); }
        }

        public MainViewModel(DevicesViewModel vm) 
        {
            CurrentViewModel = vm;
            NewCommand = new RelayCommand(NewExecute);
            OpenCommand = new RelayCommand(OpenExecute);
            SaveCommand = new RelayCommand(SaveExecute);
        }

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        { 
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); } 
        }

        // Command execution methods
        private void NewExecute()
        {
            // Implementation for New command
        }

        private void OpenExecute()
        {
            // Implementation for Open command
        }

        private void SaveExecute()
        {
            // Implementation for Save command
        }
    }
}

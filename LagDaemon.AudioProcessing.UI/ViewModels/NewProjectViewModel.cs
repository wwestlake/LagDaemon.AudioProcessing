using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace LagDaemon.AudioProcessing.UI.ViewModels
{
    public class NewProjectViewModel : ViewModelBase
    {
        private string _projectName;

        public NewProjectViewModel()
        {
            CreateCommand = new RelayCommand(Create);
        }

        public string ProjectName
        {
            get { return _projectName; }
            set { SetProperty(ref _projectName, value); }
        }

        public ICommand CreateCommand { get; private set; }

        private void Create()
        {
            // Execute the action associated with the command
            // This method will be called when the command is triggered
        }
    }
}

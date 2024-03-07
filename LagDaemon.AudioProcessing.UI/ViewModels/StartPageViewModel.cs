using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using LagDaemon.AudioProcessing.Api.Services.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.UI.ViewModels
{
    public class StartPageViewModel : ViewModelBase
    {
        private readonly IProjectManagementService _projectManagementService;

        public StartPageViewModel(IProjectManagementService projectManagementService)
        {
            _projectManagementService = projectManagementService;
        }

        public IEnumerable<Project> RecentProjects 
        {
            get
            {
                return _projectManagementService.GetRecentProjects();
            }
        }

    }
}

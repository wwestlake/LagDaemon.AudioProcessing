using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using System;
using System.Linq;

namespace LagDaemon.AudioProcessing.Api.Services
{
    public interface IProjectManagementService
    {
        IEnumerable<Project> GetRecentProjects();
        Project? OpenProject(string path);
    }
}

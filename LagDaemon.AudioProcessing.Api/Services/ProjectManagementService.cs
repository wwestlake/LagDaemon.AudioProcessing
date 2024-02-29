using LagDaemon.AudioProcessing.Api.DataManagement.FileManagement;
using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using LagDaemon.AudioProcessing.Api.DataManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Services
{
    public class ProjectManagementService : IProjectManagementService
    {
        private readonly ISerializationService _serializer;
        private readonly IErrorHandlingService _errorHandler;
        private readonly ISystemConfigurationService _systemConfigService;

        public ProjectManagementService(ISerializationService serializer, IErrorHandlingService errorHandler, ISystemConfigurationService systemConfigService)
        {
            _serializer = serializer;
            _errorHandler = errorHandler;
            _systemConfigService = systemConfigService;
        }

        public IEnumerable<Project> GetRecentProjects()
        {
#if VISUAL_STUDIO
            // Code to execute when running in Visual Studio
            return new List<Project>() 
            { 
                new Project() 
                { 
                     Name = "Test Project",
                     Author = "Bill Westlake",
                     Copyright = "2024 all rights reserved",
                     Description = "A test file",
                     Path = "d:\\projects\\someproject"
                } 
            };
#else
            // Code to execute when running standalone
#pragma warning disable CS8603 // Possible null reference return.
            return _systemConfigService.RecentProjects;
#pragma warning restore CS8603 // Possible null reference return.
#endif


        }

        public Project? OpenProject(string path)
        {
            try
            {
                using var fm = new FileManager(path);
                var content = fm.ReadFile();
                if (string.IsNullOrEmpty(content))
                {
                    throw new ApplicationException($"Unable to open file at \"{path}\"");
                }
                var project = _serializer.Deserialize<Project>(content);
                return project;

            }
            catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
            return default;
        }
    }
}

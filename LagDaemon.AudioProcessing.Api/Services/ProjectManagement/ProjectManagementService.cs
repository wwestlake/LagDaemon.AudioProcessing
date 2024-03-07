using LagDaemon.AudioProcessing.Api.Model;
using LagDaemon.AudioProcessing.Api.Services.ErrorHandling;
using LagDaemon.AudioProcessing.Api.Services.FileManagement;
using LagDaemon.AudioProcessing.Api.Services.Serialization;

namespace LagDaemon.AudioProcessing.Api.Services.ProjectManagement
{
    public class ProjectManagementService : IProjectManagementService
    {
        private readonly ISerializationService _serializer;
        private readonly IErrorHandlingService _errorHandler;
        private readonly ISystemConfigurationService _systemConfigService;
        private readonly IFileManagementService _fileManagementService;

        public ProjectManagementService(ISerializationService serializer, IErrorHandlingService errorHandler, ISystemConfigurationService systemConfigService, IFileManagementService fileManagementService)
        {
            _serializer = serializer;
            _errorHandler = errorHandler;
            _systemConfigService = systemConfigService;
            _fileManagementService = fileManagementService;
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

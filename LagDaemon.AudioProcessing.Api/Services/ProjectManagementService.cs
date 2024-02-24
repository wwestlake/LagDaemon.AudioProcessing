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
    public class ProjectManagementService
    {
        private readonly ISerializationService _serializer;
        private readonly IErrorHandlingService _errorHandler;

        public ProjectManagementService(ISerializationService serializer, IErrorHandlingService errorHandler)
        {
            _serializer = serializer;
            _errorHandler = errorHandler;
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

            } catch (Exception ex)
            {
                _errorHandler.HandleException(ex);
            }
            return default;
        }
    }
}

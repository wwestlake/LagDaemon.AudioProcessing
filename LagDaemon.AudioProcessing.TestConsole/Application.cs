using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagDaemon.AudioProcessing.Api.Services.FileManagement;
using LagDaemon.AudioProcessing.Api.Services.ProjectManagement;

namespace LagDaemon.AudioProcessing.TestConsole;
public class Application : IApplication
{
    private readonly ILoggerService _logger;
    private readonly IProjectManagementService _projectManager;
    private readonly IFileManagementService _fileManager;

    public Application(
        ILoggerService logger, 
        IProjectManagementService projectManager,
        IFileManagementService fileManager)
    {
        _logger = logger;
        _projectManager = projectManager;
        _fileManager = fileManager;
    }

    public void Run()
    {
        _logger.LogInformation("Starting Application");

        

    }
}

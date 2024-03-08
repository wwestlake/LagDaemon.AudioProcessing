using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagDaemon.AudioProcessing.Api.Services.Archive;
using LagDaemon.AudioProcessing.Api.Services.FileManagement;
using LagDaemon.AudioProcessing.Api.Services.ProjectManagement;

namespace LagDaemon.AudioProcessing.TestConsole;
public class Application : IApplication
{
    private readonly ILoggerService _logger;
    private readonly IProjectManagementService _projectManager;

    public Application(
        ILoggerService logger, 
        IProjectManagementService projectManager)
    {
        _logger = logger;
        _projectManager = projectManager;
    }

    public void Run()
    {
        _logger.LogInformation("Starting Application");

        var archive = new ArchiveHandler("D:\\Sound\\TestData\\MyProject.zip");
        archive.CreateArchive(ProjectLayout.Folders);
    }
}

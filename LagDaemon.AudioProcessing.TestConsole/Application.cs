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
        var archivePath = "D:\\Sound\\TestData\\MyProject.zip";
        var archive = new ArchiveHandler(archivePath);
        if (! File.Exists(archivePath))
        {
            archive.CreateArchive(ProjectLayout.Folders);
        }
        //archive.ImportFile(@"D:\Sound\TestData\AMaj7.mp3", ProjectLayout.DataPath("AMaj7.mp3"));

        archive.ExportFile(ProjectLayout.DataPath("AMaj7.mp3"), "D:\\Sound\\TestData\\Test\\AMaj7.mp3").Wait();

    }
}

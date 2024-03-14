using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using LagDaemon.AudioProcessing.Api.Services.Archive;
using LagDaemon.AudioProcessing.Api.Services.FileManagement;
using LagDaemon.AudioProcessing.Api.Services.ProjectManagement;
using LagDaemon.AudioProcessing.Audio.Components;
using Microsoft.Extensions.Configuration;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.TestConsole;
public class Application : IApplication
{
    private readonly IConfiguration _configuration;
    private readonly ILoggerService _logger;
    private readonly IProjectManagementService _projectManager;

    public Application(
        IConfiguration configuration,
        ILoggerService logger, 
        IProjectManagementService projectManager)
    {
        _configuration = configuration;
        _logger = logger;
        _projectManager = projectManager;
    }

    public async Task Run()
    {
        _logger.LogInformation("Starting Application");

        OpenAIClient client = new OpenAIClient(_configuration.GetSection("OpenAI")["ApiKey"]);

        var messages = new List<ChatRequestMessage>
        {
            new ChatRequestMessage { Content = "Hello!" }
            // Add more messages as needed
        };




        foreach (var choice in openAiResponse.Value.Choices)
        {
            Console.WriteLine(choice.Text);
        }

        _logger.LogInformation($"Done");

    }
}

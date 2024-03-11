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
using NAudio.Wave;

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

    public async Task Run()
    {
        _logger.LogInformation("Starting Application");

        OpenAIClient client = new OpenAIClient("");

        var message = new List<ChatRequestMessage>( );

        var options = new ChatCompletionsOptions("gpt-3.5-turbo",  );

        var chatMessage = new ChatMessage()

        var openAiResponse = 
            await client.GetChatCompletionsAsync();

        foreach (var choice in openAiResponse.Value.Choices)
        {
            Console.WriteLine(choice.Text);
        }

        _logger.LogInformation($"Done");

    }
}

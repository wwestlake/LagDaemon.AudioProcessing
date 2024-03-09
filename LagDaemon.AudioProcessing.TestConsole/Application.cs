using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public void Run()
    {
        _logger.LogInformation("Starting Application");

        MemoryStream sink = new MemoryStream();

        AudioRecorder recorder = new AudioRecorder(sink);

        recorder.StartRecording();

        Thread.Sleep(10000);

        recorder.StopRecording();

        WaveOutEvent waveOut = new WaveOutEvent();

        sink.Seek(0, SeekOrigin.Begin);
        using (WaveFileReader waveFileReader = new WaveFileReader(sink))
        {
            waveOut.Init(waveFileReader);
            waveOut.Play();

            waveOut.PlaybackStopped += (sender, e) =>
            {
                // Dispose of the WaveOutEvent instance after playback is complete
                waveOut.Dispose();
            };
        }

    }
}

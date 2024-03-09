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

        int BufferSizeMilliseconds = 1000; // 1 second

        var waveFormat = new WaveFormat(44100, 16, 1);
        int bufferSizeBytes = waveFormat.AverageBytesPerSecond * BufferSizeMilliseconds / 1000;

        BufferedWaveProvider sink = new BufferedWaveProvider(waveFormat)
        {
            BufferDuration = TimeSpan.FromMilliseconds(BufferSizeMilliseconds),
            DiscardOnBufferOverflow = true // Discard data if buffer overflows
        };

        AudioRecorder recorder = new AudioRecorder(sink);

        _logger.LogInformation($"Recording {bufferSizeBytes}");
        recorder.StartRecording();

        Thread.Sleep(10000);

        recorder.StopRecording();

        

        using (var waveOut = new WaveOut())
        {
            _logger.LogInformation($"Playing {bufferSizeBytes}");
            waveOut.Init(sink);
            waveOut.Play();

            waveOut.PlaybackStopped += (sender, e) =>
            {
                // Dispose of the WaveOutEvent instance after playback is complete
                waveOut.Dispose();
            };

        }
        _logger.LogInformation($"Done {bufferSizeBytes}");

    }
}

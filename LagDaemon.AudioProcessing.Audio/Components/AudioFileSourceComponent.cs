using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Audio.Components;
public class AudioFileSourceComponent : IAudioSource
{
    public string AudioFilePath
    {
        get;
    }
    public IAudioPipelineComponent Pipeline
    {
        get;
    }

    public event EventHandler OnStop;

    public event EventHandler<AudioDataAvailableEventArgs> OnDataAvailable;
  

    public AudioFileSourceComponent(string audioFilepath, IAudioPipelineComponent pipeline)
    {
        AudioFilePath = audioFilepath;
        Pipeline = pipeline;
    }

    private bool _running = true;

    public async Task StartAsync() 
    {
        await Task.Run(() => {
            using WaveFileReader waveFileReader = new WaveFileReader(AudioFilePath);
            int blockAlign = waveFileReader.WaveFormat.BlockAlign;
            byte[] buffer = new byte[blockAlign * 1024];
            while (_running && waveFileReader.CanRead)
            {
                waveFileReader.Read(buffer, 0, buffer.Length);
                Pipeline.ProcessAudio(buffer);
            }
        });
    }

    public void Start()
    {
        _ = StartAsync();
    }


    public void Stop()
    {
        _running = false;
        OnStop?.Invoke(this, EventArgs.Empty);
    }
}

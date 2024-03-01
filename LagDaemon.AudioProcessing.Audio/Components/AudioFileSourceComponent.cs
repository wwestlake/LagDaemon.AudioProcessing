using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Audio.Components;
public class AudioFileSourceComponent : IAudioSource
{
    public string AudioFilepath
    {
        get;
    }
    public IAudioPipelineComponent Pipeline
    {
        get;
    }

    public event EventHandler OnStop;

    event EventHandler<AudioDataAvailableEventArgs> IAudioSource.OnDataAvailable
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    public AudioFileSourceComponent(string audioFilepath, IAudioPipelineComponent pipeline)
    {
        AudioFilepath = audioFilepath;
        Pipeline = pipeline;
    }

    public async Task StartAsync() 
    {
        await Task.Run(() => {
            using WaveFileReader waveFileReader = new WaveFileReader(AudioFilepath);
            var buffer = new byte[32768];
            waveFileReader.Read(buffer);
            Pipeline.ProcessAudio(buffer);
        });
    }

    public void Start()
    {
        _ = StartAsync();
    }


    public void Stop()
    {

    }
}

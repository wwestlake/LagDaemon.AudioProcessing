using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Audio.Components;


public interface IAudioPipelineComponent
{
    void StartRecording();
    void StopRecording();

    byte[] ProcessAudio(byte[] inputData);

    List<IAudioPipelineComponent> Children
    {
        get; 
    }

    WaveOutEvent Sink
    {
        get;
    }
    WaveInEvent Source
    {
        get;
    }
}

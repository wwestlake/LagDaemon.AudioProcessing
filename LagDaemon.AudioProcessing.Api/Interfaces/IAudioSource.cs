using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Api.Interfaces
{
    public interface IAudioSource
    {
        IWavePlayer GetFromFile(string filename);
        IWavePlayer GetFromUrl(string url);
        IWavePlayer GetFromStream(WaveStream stream);
        IWavePlayer GetFromInputDevice();
    }
}
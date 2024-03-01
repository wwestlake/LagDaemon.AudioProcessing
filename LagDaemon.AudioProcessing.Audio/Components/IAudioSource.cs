namespace LagDaemon.AudioProcessing.Audio.Components;
public interface IAudioSource
{
    event EventHandler<AudioDataAvailableEventArgs> OnDataAvailable;

    // Event that fires when audio capture is stopped
    event EventHandler OnStop;

    void Start();
    void Stop();

}

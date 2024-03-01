namespace LagDaemon.AudioProcessing.Audio.Components;

public class AudioDataAvailableEventArgs : EventArgs
{
    // Audio data buffer
    public byte[] Buffer
    {
        get;
    }

    public AudioDataAvailableEventArgs(byte[] buffer)
    {
        Buffer = buffer;
    }
}
}

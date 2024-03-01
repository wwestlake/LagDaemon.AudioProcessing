using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Audio.Components;


/// <summary>
/// This class represents an audio pipeline that takes an
/// incoming audio source and pipes it to a sink after passing
/// it through any audio processing.
/// 
/// AudioComponentPipelines can be composed.  Children are called 
/// in the order that they are added to the Children List.
/// </summary>
public abstract class AudioPipelineComponent : IAudioPipelineComponent
{

    /// <summary>
    /// Children components to be run in order.  
    /// </summary>
    public List<IAudioPipelineComponent> Children { get; } = new();


    /// <summary>
    /// Constructs an AudioPipelineComponent
    /// </summary>
    /// <param name="source">An audio source, device or file</param>
    /// <param name="sink">An audio sink, device or file</param>
    /// <exception cref="ArgumentNullException">both source and sink must not be null</exception>
    public AudioPipelineComponent(WaveInEvent source, WaveOutEvent sink)
    {
        if (source == null) throw new ArgumentNullException(nameof(source), "The audio source must not be null");
        if (sink == null) throw new ArgumentNullException(nameof(sink), "The audio sink must not be null");
        Source = source;
        Sink = sink;
        Source.DataAvailable += OnDataAvailable;
        Sink.PlaybackStopped += OnPlaybackStopped;
    }

    protected WaveFileReader WaveFileReader { get; }  

    protected void OnDataAvailable(object sender, WaveInEventArgs e)
    {
        var processedData = ProcessAudio(e.Buffer);
        if (processedData != null)
        {
            foreach (var child in Children)
            {
                processedData = child.ProcessAudio(processedData);
            }
            Sink.Play();
            Sink.Init(new RawSourceWaveStream(new MemoryStream(processedData), Sink.OutputWaveFormat));
        }
    }

    /// <summary>
    /// Start recording
    /// </summary>
    public void StartRecording()
    {
        Source.StartRecording();
    }

    /// <summary>
    /// Stop capturing audio from the device
    /// </summary>
    public void StopRecording()
    {
        Source.StopRecording();
    }

    /// <summary>
    /// Override and process the audio data
    /// </summary>
    /// <param name="inputData">The incoming audio data</param>
    /// <returns>The modified audio data</returns>
    public abstract byte[] ProcessAudio(byte[] inputData);

    protected abstract void OnPlaybackStopped(object sender, StoppedEventArgs e);


    /// <summary>
    /// The audio source
    /// </summary>
    public WaveInEvent Source
    {
        get;
    }

    /// <summary>
    /// The audio sink
    /// </summary>
    public WaveOutEvent Sink
    {
        get;
    }
}

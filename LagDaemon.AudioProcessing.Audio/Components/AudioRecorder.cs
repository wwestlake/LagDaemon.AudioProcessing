using NAudio.Wave;


namespace LagDaemon.AudioProcessing.Audio.Components;
public class AudioRecorder
{
    private WaveInEvent waveIn;
    private BufferedWaveProvider _outputStream;

    public AudioRecorder(BufferedWaveProvider outputStream)
    {
        // Initialize the WaveInEvent
        waveIn = new WaveInEvent();

        // Set up event handlers
        waveIn.DataAvailable += WaveIn_DataAvailable;
        waveIn.RecordingStopped += WaveIn_RecordingStopped;

        // Set desired audio format (e.g., 16-bit PCM, 44.1kHz, mono)
        waveIn.WaveFormat = outputStream.WaveFormat;

        // Initialize the output stream
        _outputStream = outputStream;
    }

    public void StartRecording()
    {
        // Start recording
        waveIn.StartRecording();
    }

    public void StopRecording()
    {
        // Stop recording
        waveIn.StopRecording();
    }

    private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
    {
        // Write captured audio data to the output stream
        _outputStream.AddSamples(e.Buffer, 0, e.BytesRecorded);
    }

    private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
    {
        // Dispose of the WaveInEvent instance
        waveIn.Dispose();

        //byte[] recordedData = outputStream.ToArray();

        // Close the output stream
        //outputStream.Position = 0;

        // Optionally, do something with the recorded audio data (e.g., save it to a file)

        //_sink.Write(recordedData, 0, recordedData.Length);
        //_sink.Flush();
    }
}

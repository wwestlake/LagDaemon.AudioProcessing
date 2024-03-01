using Castle.MicroKernel.Registration;
using Castle.Windsor;
using LagDaemon.AudioProcessing.Api.DataManagement.FileManagement;
using LagDaemon.AudioProcessing.Api.DataManagement.Implementations;
using LagDaemon.AudioProcessing.Api.DataManagement.Models;
using LagDaemon.AudioProcessing.Api.DataManagement.Services;
using LagDaemon.AudioProcessing.Api.Interfaces;
using LagDaemon.AudioProcessing.Api.Services;
using LagDaemon.AudioProcessing.Audio.Components;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string audioFilePath = "D:\\Music\\AI_Test_Kitchen_a_rising_synth_is_playing_an_arpeggio_with_a (1).mp3";

            var waveFileReader = new WaveFileReader(audioFilePath);

            // Create an instance of WaveOutEvent for audio playback
            var waveOut = new WaveOutEvent();

            // Create an instance of your AudioPipelineComponent with WaveFileReader and WaveOutEvent
            var audioPipelineComponent = new YourAudioPipelineComponent(waveFileReader, waveOut);

            // Start audio playback
            waveOut.Init(waveFileReader);
            waveOut.Play();

            // Keep the console application running while audio is playing
            Console.WriteLine("Playing audio. Press any key to stop...");
            Console.ReadKey();

            // Stop audio playback
            waveOut.Stop();
            waveOut.Dispose();
            waveFileReader.Dispose();
        }
    }


    // Your AudioPipelineComponent class (replace with your actual implementation)
    public class YourAudioPipelineComponent : AudioPipelineComponent
    {
        public YourAudioPipelineComponent(WaveInEvent source, WaveOutEvent sink)
            : base(source, sink)
        {
        }

        // Implement the abstract method for processing audio data
        public override byte[] ProcessAudio(byte[] inputData)
        {
            // Process audio data as needed
            // For this example, we'll just return the input data unchanged
            return inputData;
        }

        // Implement the abstract method for handling playback stopped event
        protected override void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Handle playback stopped event as needed
        }
    }

}

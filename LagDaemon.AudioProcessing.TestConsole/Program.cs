using System;
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
            string audioFilePath = "D:\\Music\\JamTracks\\Personal\\BasicGuitar\\Audio\\02-Riff-1-231128_0934.wav";

            var waveFileReader = new WaveFileReader(audioFilePath);

            // Create an instance of WaveOutEvent for audio playback
            var waveOut = new WaveOutEvent();

            // Create an instance of your AudioPipelineComponent with WaveFileReader and WaveOutEvent
            var audioPipelineComponent = new YourAudioPipelineComponent(new WaveInEvent(), waveOut, waveFileReader.WaveFormat);

            var audioFileSourceComponent = new AudioFileSourceComponent(audioFilePath, audioPipelineComponent);


            audioFileSourceComponent.Start();

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
        private WaveFormat _format;

        public YourAudioPipelineComponent(WaveInEvent source, WaveOutEvent sink, WaveFormat format)
            : base(source, sink)
        {
            _format = format;
        }

        // Implement the abstract method for processing audio data
        public override byte[] ProcessAudio(byte[] inputData)
        {
            // Process audio data as needed
            // For this example, we'll just return the input data unchanged
            Sink.Init(new RawSourceWaveStream(new MemoryStream(inputData, 0, inputData.Length), _format));
            Sink.Play();
            return inputData;
        }

        // Implement the abstract method for handling playback stopped event
        protected override void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            // Handle playback stopped event as needed
        }
    }

}

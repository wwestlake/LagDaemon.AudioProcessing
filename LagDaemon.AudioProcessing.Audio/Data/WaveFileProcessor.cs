using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Audio.Data
{
    public static class WaveFileProcessor
    {
        public static IEnumerable<float[][]> ReadWavFile(string filePath, int blockSize) 
        { 
            using (var reader = new WaveFileReader(filePath))
            {
                return ReadAudioFile(reader, blockSize);
            }
        }
        public static IEnumerable<float[][]> ReadAudioFile(WaveStream reader, int blockSize)
        {
            int channels = reader.WaveFormat.Channels;
            int bytesPerSample = reader.WaveFormat.BitsPerSample / 8;
            int blockSizeBytes = blockSize * channels * bytesPerSample;

            byte[] buffer = new byte[blockSizeBytes];
            int bytesRead;

            while ((bytesRead = reader.Read(buffer, 0, blockSizeBytes)) > 0)
            {
                int samplesRead = bytesRead / (channels * bytesPerSample);

                float[][] samples = new float[channels][];
                for (int channel = 0; channel < channels; channel++)
                {
                    samples[channel] = new float[samplesRead];
                }

                for (int sample = 0; sample < samplesRead; sample++)
                {
                    for (int channel = 0; channel < channels; channel++)
                    {
                        // Convert bytes to float samples
                        int startIndex = sample * channels * bytesPerSample + channel * bytesPerSample;
                        samples[channel][sample] = BytesToFloat(buffer, startIndex, bytesPerSample);
                    }
                }

                yield return samples;
            }
        }

        public static WaveStream SinewaveGenerator(int sampleRate, int channels, double frequency, int lengthInSeconds)
        {
            return SignalGenerator(sampleRate, channels, frequency, lengthInSeconds, Math.Sin);
        }


        public static WaveStream SignalGenerator(int sampleRate, int channels, double frequency, int lengthInSeconds, Func<double, double> signal)
        {
            int totalSamples = sampleRate * lengthInSeconds;
            double phaseIncrement = frequency * 2 * Math.PI / sampleRate;

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            for (int i = 0; i < totalSamples; i++)
            {
                double sample = signal(i * phaseIncrement);
                WriteSample(writer, sample);
                if (channels == 2)
                {
                    WriteSample(writer, sample); // For stereo
                }
            }

            stream.Position = 0;
            return new RawSourceWaveStream(stream, new WaveFormat(sampleRate, 16, channels));
        }

        private static void WriteSample(BinaryWriter writer, double sample)
        {
            short value = (short)(sample * short.MaxValue);
            writer.Write(value);
        }
    

    private static float BytesToFloat(byte[] bytes, int startIndex, int bytesPerSample)
        {
            float sampleValue = 0;
            for (int i = 0; i < bytesPerSample; i++)
            {
                sampleValue += bytes[startIndex + i] << (i * 8);
            }
            return sampleValue / (float.MaxValue + 1);
        }



    }
}

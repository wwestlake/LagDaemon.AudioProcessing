using NAudio.Wave;
using System;

namespace LagDaemon.AudioProcessing.Audio.Data
{

    public class SineWaveProvider : WaveProvider32
    {
        private double phaseAngle;
        private double phaseIncrement;

        public SineWaveProvider(int sampleRate, int channels, double frequency)
        {
            SetWaveFormat(sampleRate, channels);
            phaseIncrement = frequency * 2 * Math.PI / sampleRate;
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            for (int n = 0; n < sampleCount; n++)
            {
                for (int c = 0; c < WaveFormat.Channels; c++)
                {
                    buffer[offset + n * WaveFormat.Channels + c] = (float)Math.Sin(phaseAngle);
                }
                phaseAngle += phaseIncrement;
                if (phaseAngle > 2 * Math.PI)
                {
                    phaseAngle -= 2 * Math.PI;
                }
            }
            return sampleCount;
        }
    }

}

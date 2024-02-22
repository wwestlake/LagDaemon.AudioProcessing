using System;
using System.Linq;

namespace LagDaemon.AudioProcessing.Api.Model
{
    public interface IAudioBlock
    {
        float Read(int channel, int position);
        void Write(int channel, int position, float data);

        int Channels { get; }
        int Length { get; }
    }
}

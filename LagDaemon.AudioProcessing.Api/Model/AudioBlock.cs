using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Model
{
    /// <summary>
    /// Manages blocks of audio data by channel.  
    /// Audio components accept and AudioBlock as input, and return an AudioBlock
    /// </summary>
    public class AudioBlock : IAudioBlock
    {
        private readonly float[][] _audioBlock;

        public AudioBlock(float[][] audioBlock)
        {
            _audioBlock = audioBlock;
        }

        public float Read(int channel, int position)
        {
            return _audioBlock[channel][position];
        }

        public void Write(int channel, int position, float data)
        {
            _audioBlock[channel][position] = data;
        }

        public int Length { get { return _audioBlock[0].Length; } }
        public int Channels { get { return _audioBlock.Length; } }
    }
}

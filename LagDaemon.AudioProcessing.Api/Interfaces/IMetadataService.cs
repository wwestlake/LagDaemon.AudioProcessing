using LagDaemon.AudioProcessing.Api.Models;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Api.Interfaces
{
    public interface IMetadataService
    {
        IEnumerable<AudioDeviceModel> GetWaveOutCapabilities();
        IEnumerable<AudioDeviceModel> GetWaveInCapabilities();
    }
}

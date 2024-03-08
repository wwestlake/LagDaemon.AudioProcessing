using LagDaemon.AudioProcessing.Api.Interfaces;
using LagDaemon.AudioProcessing.Api.Models;
using LagDaemon.AudioProcessing.Audio.Devices;
using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Api.Services.SystemServices
{
    public class MetadataService : IMetadataService
    {
        public IEnumerable<AudioDeviceModel> GetWaveInCapabilities()
        {
            var devices = DeviceCapabilities.GetInputDevicesCapabilities();
            foreach (var device in devices)
            {
                yield return new AudioDeviceModel
                {
                    ManufacturerGuid = device.ManufacturerGuid.ToString(),
                    ProductName = device.ProductName,
                    NumberOfChannels = device.Channels
                };
            }
        }

        public IEnumerable<AudioDeviceModel> GetWaveOutCapabilities()
        {
            var devices = DeviceCapabilities.GetOutputDevicesCapabilities();
            foreach (var device in devices)
            {
                yield return new AudioDeviceModel
                {
                    ManufacturerGuid = device.ManufacturerGuid.ToString(),
                    ProductName = device.ProductName,
                    NumberOfChannels = device.Channels
                };
            }
        }

    }
}

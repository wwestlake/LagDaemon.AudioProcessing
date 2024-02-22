using LagDaemon.AudioProcessing.Api.Interfaces;
using LagDaemon.AudioProcessing.Api.Models;
using LagDaemon.AudioProcessing.UI.ViewModels.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.UI.ViewModels
{
    public class DevicesViewModel : ViewModelBase
    {
        private readonly IMetadataService _metadataService;

        public DevicesViewModel(IMetadataService metadataService) 
        {
            _metadataService = metadataService;
        }

        public IEnumerable<AudioDeviceCardViewModel> InputDevices => GetInputDevices();

        public IEnumerable<AudioDeviceCardViewModel> OutputDevices => GetOutputDevices();

        private IEnumerable<AudioDeviceCardViewModel> GetInputDevices()
        {
            var result = new List<AudioDeviceCardViewModel>();  
            foreach (var device in _metadataService.GetWaveInCapabilities()) 
            { 
                result.Add(new AudioDeviceCardViewModel(device));
            }
            return result;
        }

        private IEnumerable<AudioDeviceCardViewModel> GetOutputDevices()
        {
            var result = new List<AudioDeviceCardViewModel>();
            foreach (var device in _metadataService.GetWaveOutCapabilities())
            {
                result.Add(new AudioDeviceCardViewModel(device));
            }
            return result;
        }

    }
}

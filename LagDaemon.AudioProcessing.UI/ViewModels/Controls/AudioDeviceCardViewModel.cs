using LagDaemon.AudioProcessing.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.UI.ViewModels.Controls
{
    public class AudioDeviceCardViewModel : ViewModelBase
    {
        readonly AudioDeviceModel model;
        public AudioDeviceCardViewModel(AudioDeviceModel model) 
        {
            this.model = model;
        }

        public string ManufacturerGuid => model.ManufacturerGuid;
        public string ProductName => model.ProductName;
        public int NumberOfChannels => model.NumberOfChannels;

    }
}

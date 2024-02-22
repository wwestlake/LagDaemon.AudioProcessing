using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Models
{
    public class AudioDeviceModel
    {
        public string ManufacturerGuid { get; set; }
        public string ProductName { get; set; }
        public int NumberOfChannels { get; set; }
    }
}

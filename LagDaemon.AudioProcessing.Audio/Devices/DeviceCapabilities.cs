using NAudio.Wave;

namespace LagDaemon.AudioProcessing.Audio.Devices
{
    public static class DeviceCapabilities
    {

        public static IEnumerable<WaveInCapabilities> GetInputDevicesCapabilities()
        {
            // Initialize a list to store the capabilities of each output device
            List<WaveInCapabilities> capabilitiesList = new List<WaveInCapabilities>();

            // Iterate through the available output devices
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                // Initialize a temporary WaveOut instance
                using (var waveOut = new WaveIn())
                {
                    // Retrieve the capabilities of the current output device
                    capabilitiesList.Add(WaveIn.GetCapabilities(i));
                }
            }

            return capabilitiesList;
        }



        public static IEnumerable<WaveOutCapabilities> GetOutputDevicesCapabilities()
        {
            // Initialize a list to store the capabilities of each output device
            List<WaveOutCapabilities> capabilitiesList = new List<WaveOutCapabilities>();

            // Iterate through the available output devices
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                // Initialize a temporary WaveOut instance
                using (var waveOut = new WaveOut())
                {
                    // Retrieve the capabilities of the current output device
                    capabilitiesList.Add(WaveOut.GetCapabilities(i));
                }
            }

            return capabilitiesList;
        }
    }
}

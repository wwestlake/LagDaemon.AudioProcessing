using LagDaemon.AudioProcessing.Api.Interfaces;
using LagDaemon.AudioProcessing.Api.Model;
using LagDaemon.AudioProcessing.Api.Services.FileManagement;

namespace LagDaemon.AudioProcessing.Api.Services.SystemServices
{
    public class SystemConfigurationService : ISystemConfigurationService
    {
        private readonly ISerializer _serializer;
        private AppConfig _appConfig;

        public SystemConfigurationService(ISerializer serializer)
        {
            _serializer = serializer;
            LoadAppConfig();
        }

        void SetDefaults()
        {
            _appConfig.UserPreferences.Add("test", 1);
            _appConfig.UserPreferences.Add("log.fileath", "system.log");
        }

        public void Save()
        {
            using var appConfigFile = new FileManager(SystemPaths.AppConfig);
            appConfigFile.WriteToFile(_serializer.Serialize(_appConfig));
        }

        void LoadAppConfig()
        {
            using var appConfigFile = new FileManager(SystemPaths.AppConfig);
            var content = appConfigFile.ReadFile();
            if (string.IsNullOrEmpty(content))
            {
                _appConfig = new AppConfig();
                SetDefaults();
                appConfigFile.WriteToFile(_serializer.Serialize(_appConfig));
            }
            else
            {
                _appConfig = _serializer.Deserialize<AppConfig>(content);

                foreach (var kvp in _appConfig.UserPreferences)
                {
                    if (kvp.Value is long longValue)
                    {
                        // Check if the long value can fit into int range
                        if (longValue >= int.MinValue && longValue <= int.MaxValue)
                        {
                            // Add or update key-value pair with int value
                            _appConfig.AddOrUpdate(kvp.Key, (int)longValue);
                        }
                        else
                        {
                            throw new OverflowException($"Value '{longValue}' is too large or too small for an Int32.");
                        }
                    }
                    else
                    {
                        // Add or update key-value pair with original value
                        _appConfig.AddOrUpdate(kvp.Key, kvp.Value);
                    }
                }

            }
        }

        public IEnumerable<FileDescription> RecentFiles => _appConfig.RecentFiles;
        public IEnumerable<Project> RecentProjects => _appConfig.RecentProjects;

        public T? GetSetting<T>(string setting)
        {
            return (T)_appConfig.UserPreferences[setting];
        }

        public void SetSetting<T>(string setting, T value)
        {
            _appConfig.UserPreferences[setting] = value;
        }
    }
}

using LagDaemon.AudioProcessing.Api.Model;
using System;
using System.Linq;

namespace LagDaemon.AudioProcessing.Api.Services.SystemServices
{
    public interface ISystemConfigurationService
    {
        T? GetSetting<T>(string setting);
        void SetSetting<T>(string setting, T? value);

        IEnumerable<FileDescription>? RecentFiles
        {
            get;
        }
        IEnumerable<Project>? RecentProjects
        {
            get;
        }

        void Save();
    }
}

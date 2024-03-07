using LagDaemon.AudioProcessing.Api.DataManagement.Implementations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Model
{
    public class AppConfig
    {
        public IList<Project> RecentProjects { get; private set; } = new List<Project>();
        public IList<FileDescription> RecentFiles { get; private set; } = new List<FileDescription>();

        public IDictionary<string, object> UserPreferences { get; set; } = new Dictionary<string, object>();

        public void AddOrUpdate<T>(string key, T value)
        {
            UserPreferences[key] = value;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Model
{
    public class Project
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public string Version
        {
            get; set;
        }

        public string Author
        {
            get; set;
        }

        public string Copyright
        {
            get; set;
        }

        public string Path
        {
            get; set;
        }
        public IList<FileDescription> Files { get; set; } = new List<FileDescription>();
        public IList<Project> SubProjects { get; set; } = new List<Project>();

        public IDictionary<string, dynamic?> ProjectSettings { get; set; } = new Dictionary<string, object?>();

        public T? GetProjectSetting<T>(string setting)
        {
            if (ProjectSettings.ContainsKey(setting))
            {
                return (T)ProjectSettings[setting];
            }
            return default;
        }

        public void SetProjectSetting<T>(string setting, T value)
        {
            if (!ProjectSettings.ContainsKey(setting))
            {
                ProjectSettings.Add(setting, value);
            }
            else
            {
                ProjectSettings[setting] = value;
            }
        }

    }
}

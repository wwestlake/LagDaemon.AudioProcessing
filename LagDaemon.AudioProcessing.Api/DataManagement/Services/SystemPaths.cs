using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.DataManagement.Services
{
    public static class SystemPaths
    {
        public static string RootSystemPath =>
            $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{Path.DirectorySeparatorChar}LagDaemon{Path.DirectorySeparatorChar}AudioProcessing";

        public static string GetPath(string filename)
        {
            return $"{RootSystemPath}{Path.DirectorySeparatorChar}{filename}";
        }

        public static string AppConfig => GetPath("AppConfig.json");
    }
}

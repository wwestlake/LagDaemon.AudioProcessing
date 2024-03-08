using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Services.ProjectManagement;
public static class ProjectLayout
{
    public static string sep = Path.DirectorySeparatorChar.ToString();

    public static string Metadata => $"metadata";
    public static string Indices => $"{Metadata}{sep}indicies";

    public static string Users => $"{Metadata}{sep}users";
    public static string Data => $"data";

    public static IEnumerable<string> Folders => new[]
    {
        Metadata, Indices, Users, Data
    };

}

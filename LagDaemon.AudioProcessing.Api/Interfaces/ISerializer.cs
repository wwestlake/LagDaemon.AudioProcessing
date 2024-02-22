using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Interfaces
{
    public interface ISerializer
    {
        string Serialize<T>(T item) where T : class;
        T? Deserialize<T>(string item) where T : class;
    }
}

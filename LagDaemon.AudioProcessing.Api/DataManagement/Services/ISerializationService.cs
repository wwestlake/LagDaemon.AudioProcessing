using System;
using System.Linq;

namespace LagDaemon.AudioProcessing.Api.DataManagement.Services
{
    public interface ISerializationService
    {
        T Deserialize<T>(string item) where T : class;
        string Serialize<T>(T item) where T : class;
    }
}

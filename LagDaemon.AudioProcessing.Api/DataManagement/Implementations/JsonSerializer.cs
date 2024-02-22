using LagDaemon.AudioProcessing.Api.Interfaces;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace LagDaemon.AudioProcessing.Api.DataManagement.Implementations
{
    public class JsonSerializerImpl : ISerializer
    {
        public JsonSerializerImpl() 
        {
        }

        public T? Deserialize<T>(string item) where T : class
        {
            return (T?)JsonConvert.DeserializeObject<T>(item);  
        }

        public string Serialize<T>(T item) where T : class 
            => JsonConvert.SerializeObject(item);
    }



}

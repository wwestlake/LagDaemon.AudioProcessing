using LagDaemon.AudioProcessing.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.DataManagement.Services
{
    public class SerializationService : ISerializationService
    {
        readonly ISerializer _serializer;
        public SerializationService(ISerializer serializer)
        {
            this._serializer = serializer;
        }

        public T Deserialize<T>(string item) where T : class
        {
            return _serializer.Deserialize<T>(item);
        }

        public string Serialize<T>(T item) where T : class
        {
            return _serializer.Serialize<T>(item);
        }


    }
}

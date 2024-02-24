namespace LagDaemon.Peridot
{
    public class TaskExecutionContext : ITaskExecutionContext
    {
        private readonly IDictionary<string, dynamic> _keyValuePairs = new Dictionary<string, dynamic>();
        public CancellationToken CancellationToken { get; set; }

        public T Get<T>(string key) { return (T)_keyValuePairs[key]; }
        public void Set<T>(string key, T value)
        {
            if (null == value)
            {
                throw new ArgumentNullException("value must not be null");
            }
            if (!_keyValuePairs.ContainsKey(key))
            {
                _keyValuePairs.Add(key, value);
            }
            else
            {
                _keyValuePairs[key] = value;
            }
        }

    }
}

namespace LagDaemon.Peridot
{
    public interface ITaskExecutionContext
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);

        CancellationToken CancellationToken { get; set;  }
    }
}

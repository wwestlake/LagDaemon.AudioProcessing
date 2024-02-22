namespace LagDaemon.AudioProcessing.Api.DataManagement.FileManagement
{
    public class FileChangedEventArgs : EventArgs
    {
        public WatcherChangeTypes ChangeType { get; }

        public FileChangedEventArgs(WatcherChangeTypes changeType)
        {
            ChangeType = changeType;
        }
    }
}

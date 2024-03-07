namespace LagDaemon.AudioProcessing.Api.Services.FileManagement
{
    public class FileChangedEventArgs : EventArgs
    {
        public WatcherChangeTypes ChangeType
        {
            get;
        }

        public FileChangedEventArgs(WatcherChangeTypes changeType)
        {
            ChangeType = changeType;
        }
    }
}

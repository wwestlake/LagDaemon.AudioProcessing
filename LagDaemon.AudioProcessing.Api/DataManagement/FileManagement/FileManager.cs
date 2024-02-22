using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.DataManagement.FileManagement
{
    public class FileManager : IDisposable
    {
        private readonly string filePath;
        private FileSystemWatcher watcher;

        public event EventHandler<FileChangedEventArgs> FileChanged;

        public FileManager(string filePath)
        {
            this.filePath = filePath;

            var pathOnly = Path.GetDirectoryName(filePath);


            if (! Path.Exists(pathOnly))
            {
                Directory.CreateDirectory(pathOnly);
            }

            if (! File.Exists(filePath))
            {
                var fs = File.Create(filePath);
                fs.Close();
                fs.Dispose();
            }

            // Initialize file system watcher to monitor file changes
            watcher = new FileSystemWatcher(Path.GetDirectoryName(filePath) ?? string.Empty);
            watcher.Filter = Path.GetFileName(filePath);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += OnFileChanged;
            watcher.EnableRaisingEvents = true;
        }

        public string ReadFile()
        {
            return File.ReadAllText(filePath);
        }

        public void WriteToFile(string content)
        {
            // Disable the watcher temporarily
            watcher.EnableRaisingEvents = false;

            File.WriteAllText(filePath, content);

            // Re-enable the watcher after writing to the file
            watcher.EnableRaisingEvents = true;
        }

        public void OpenFile()
        {
            System.Diagnostics.Process.Start(filePath);
        }

        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            // Check if the change was made by the FileManager
            if (e.ChangeType == WatcherChangeTypes.Changed &&
                e.FullPath == filePath)
            {
                return;
            }

            // Raise the FileChanged event for subscribers
            FileChanged?.Invoke(this, new FileChangedEventArgs(e.ChangeType));
        }

        public void Dispose()
        {
            if (watcher != null)
            {
                watcher.Dispose();
                watcher = null;
            }
        }
    }
}

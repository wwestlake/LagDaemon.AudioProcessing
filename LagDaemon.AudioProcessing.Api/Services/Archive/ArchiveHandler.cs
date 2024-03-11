using System.IO.Compression;

namespace LagDaemon.AudioProcessing.Api.Services.Archive;
public class ArchiveHandler
{
    private readonly string _path;

    public ArchiveHandler(string path)
    {
        this._path = path;
    }

    public void CreateArchive(IEnumerable<string> initialItems)
    {
        if (File.Exists(this._path)) 
        { 
            throw new ApplicationException($"Archive already exists: {_path}"); 
        }
        using var archiveStream = new FileStream(_path, FileMode.Create);
        using var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create);

        foreach (var item in initialItems)
        {
            archive.CreateEntry($"{item}/");
        }
    }

    public enum EntryType
    {
        Files,
        Folders
    }

    public IEnumerable<string> ListEntries(string directoryPath = null, EntryType entryType = EntryType.Files)
    {
        using var archiveStream = new FileStream(_path, FileMode.Open);
        using var archive = new ZipArchive(archiveStream, ZipArchiveMode.Update);

        var filteredEntries = archive.Entries;

        if (!string.IsNullOrEmpty(directoryPath))
        {
            filteredEntries = (System.Collections.ObjectModel.ReadOnlyCollection<ZipArchiveEntry>)filteredEntries.Where(entry =>
            {
                string normalizedPath = entry.FullName.Replace('\\', '/');
                return normalizedPath.StartsWith(directoryPath + "/", StringComparison.OrdinalIgnoreCase);
            });
        }

        IEnumerable<string> entries = filteredEntries
            .Select(entry =>
            {
                string normalizedPath = entry.FullName.Replace('\\', '/');
                string relativePath = normalizedPath;
                if (!string.IsNullOrEmpty(directoryPath))
                {
                    relativePath = normalizedPath.Substring(directoryPath.Length).Trim('/');
                }
                return new { IsFolder = relativePath.EndsWith('/'), Path = relativePath };
            })
            .Where(entry => entryType == EntryType.Files ? !entry.IsFolder : entry.IsFolder)
            .Select(entry => entry.Path);

        return entries;
    }
    public void CreateItem(string path, byte[] data)
    {
        if (! File.Exists(this._path))
        {
            throw new ApplicationException($"Archive not found: {_path}");
        }

        using var archiveStream = File.Open(_path, FileMode.Open);
        using var archive = new ZipArchive(archiveStream, ZipArchiveMode.Update);
        var item = archive.CreateEntry(path);
        using var stream = item.Open();
        stream.Write(data, 0, data.Length);
        
    }

    public void ImportFile(string filename, string pathInProject)
    {
        using var archiveStream = File.Open(_path, FileMode.Open);
        using var archive = new ZipArchive(archiveStream, ZipArchiveMode.Update);
        archive.CreateEntryFromFile(filename, $"{pathInProject}");
    }

    public async Task ExportFile(string pathInProject, string pathInFileSystem)
    {
        using var archiveStream = File.Open(_path, FileMode.Open);
        using var archive = new ZipArchive(archiveStream, ZipArchiveMode.Read);
        var entry = archive.GetEntry(pathInProject);
        if (entry != null)
        {
            using (var entryStream = entry.Open())
            using (var fileStream = File.OpenWrite(pathInFileSystem))
            {
                await entryStream.CopyToAsync(fileStream);
            }
        }
        else
        {
            throw new FileNotFoundException($"Entry '{pathInProject}' not found in the zip archive.");
        }
    }
}

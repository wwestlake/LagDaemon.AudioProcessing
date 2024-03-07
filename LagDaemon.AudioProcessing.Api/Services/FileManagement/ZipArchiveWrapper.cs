using System.IO;
using System.IO.Compression;

namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;

public class ZipArchiveWrapper : IZipArchive
{
    private ZipArchive? _archive = null;

    public ZipArchiveWrapper()
    {
    }

    public void Open(string path)
    {
        _archive = new ZipArchive(File.OpenRead(path));
    }

    public void Open(Stream stream)
    {
        _archive = new ZipArchive(stream);
    }

    public ZipArchiveEntry CreateEntry(string entryName)
    {
        if (_archive == null) 
        { 
            throw new ApplicationException("Must open an archive file first."); 
        }
        return _archive.CreateEntry(entryName);
    }

    public ZipArchiveEntry? GetEntry(string entryName)
    {
        if (_archive == null) 
        { 
            throw new ApplicationException("Must open an archive file first."); 
        }
        return _archive.GetEntry(entryName);
    }

    public void Dispose()
    {
        _archive.Dispose();
    }
}

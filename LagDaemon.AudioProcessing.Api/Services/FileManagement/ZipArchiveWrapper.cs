using System.IO.Compression;

namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;

public interface IZipArchive : IDisposable
{
    ZipArchiveEntry CreateEntry(string entryName);
    ZipArchiveEntry GetEntry(string entryName);
}

public class ZipArchiveWrapper : IZipArchive
{
    private readonly ZipArchive _archive;

    public ZipArchiveWrapper(ZipArchive archive)
    {
        _archive = archive ?? throw new ArgumentNullException(nameof(archive));
    }

    public ZipArchiveEntry CreateEntry(string entryName)
    {
        return _archive.CreateEntry(entryName);
    }

    public ZipArchiveEntry GetEntry(string entryName)
    {
        return _archive.GetEntry(entryName);
    }

    public void Dispose()
    {
        _archive.Dispose();
    }
}

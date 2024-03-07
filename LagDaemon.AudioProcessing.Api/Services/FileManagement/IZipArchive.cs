using System.IO.Compression;

namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;

public interface IZipArchive : IDisposable
{
    void Open(string path);
    void Open(Stream stream);
    ZipArchiveEntry CreateEntry(string entryName);
    ZipArchiveEntry GetEntry(string entryName);
}

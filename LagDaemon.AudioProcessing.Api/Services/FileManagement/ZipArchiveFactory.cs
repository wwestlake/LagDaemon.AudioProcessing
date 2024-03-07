using System.IO.Compression;

namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;
public class ZipArchiveFactory : IZipArchiveFactory
{
    public ZipArchive Create(string zipFilePath)
    {
        return new ZipArchive(File.OpenRead( zipFilePath ));
    }
}

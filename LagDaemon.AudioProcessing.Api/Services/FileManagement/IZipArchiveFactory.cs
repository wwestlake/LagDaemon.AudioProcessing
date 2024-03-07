using System.IO.Compression;

public interface IZipArchiveFactory
{
    ZipArchive Create(string zipFilePath);
}

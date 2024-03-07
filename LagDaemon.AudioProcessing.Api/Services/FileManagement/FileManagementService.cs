using System.IO.Compression;
using System.Text;

namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;
public class FileManagementService : IFileManagementService
{
    private readonly IZipArchive _archive;

    public FileManagementService(IZipArchive archive)
    {
        _archive = archive;
    }

    public void WriteEntry(string entryName, byte[] fileContents)
    {
        // Create a new entry in the zip archive with the specified entry name
        ZipArchiveEntry entry = _archive.CreateEntry(entryName);

        // Write the file content to the zip entry
        using Stream entryStream = entry.Open();
        entryStream.Write(fileContents, 0, fileContents.Length);
    }

    public void WriteEntry(string entryName, string fileContents)
    {
        byte[] contents = Encoding.UTF8.GetBytes(fileContents);
        WriteEntry(entryName, contents);
    }
    public ArchiveEntryInfo ReadBinaryFile(string entryName)
    {
        ArchiveEntryInfo entryInfo = new ArchiveEntryInfo();
        entryInfo.FilePath = entryName;

        ZipArchiveEntry entry = _archive.GetEntry(entryName);
        if (entry != null)
        {
            // Read the content of the entry
            using Stream entryStream = entry.Open();
            using MemoryStream memoryStream = new MemoryStream();
            entryStream.CopyTo(memoryStream);
            entryInfo.BinaryContent = memoryStream.ToArray();
            entryInfo.FileSize = entry.Length;
        }

        return entryInfo;
    }

    public ArchiveEntryInfo ReadTextFile(string entryName)
    {
        ArchiveEntryInfo entryInfo = new ArchiveEntryInfo();
        entryInfo.FilePath = entryName;

        ZipArchiveEntry entry = _archive.GetEntry(entryName);
        if (entry != null)
        {
            // Read the content of the entry
            using Stream entryStream = entry.Open();
            using StreamReader reader = new StreamReader(entryStream);
            entryInfo.TextContent = reader.ReadToEnd();
            entryInfo.FileSize = entry.Length;
        }

        return entryInfo;
    }
}

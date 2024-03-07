namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;
public interface IFileManagementService
{
    ArchiveEntryInfo ReadBinaryFile(string entryName);
    ArchiveEntryInfo ReadTextFile(string entryName);
    void WriteEntry(string entryName, byte[] fileContents);
    void WriteEntry(string entryName, string fileContents);
}

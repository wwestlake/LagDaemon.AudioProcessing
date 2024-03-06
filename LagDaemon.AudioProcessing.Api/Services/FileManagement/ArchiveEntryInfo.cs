using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagDaemon.AudioProcessing.Api.Services.FileManagement;

public enum ArchiveEntryType
{
    Text,
    Binary
}

public class ArchiveEntryInfo
{
    public ArchiveEntryType Type { get; set; }
    public string FilePath { get; set; }
    public long FileSize { get; set; }
    public byte[] BinaryContent { get; set; }
    public string TextContent { get; set; }
}

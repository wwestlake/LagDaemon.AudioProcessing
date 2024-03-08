using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void CreateItem(string path, byte[] data)
    {
        if (! File.Exists(this._path))
        {
            throw new ApplicationException($"Archive not found: {_path}");
        }

        using var archiveStream = File.Open(_path, FileMode.Create);
        using var archive = new ZipArchive(archiveStream);
        var item = archive.CreateEntry(path);
        item.Open().Write(data, 0, data.Length);
    }


}

using NX.Libs.CompressionLib.Interfaces;
using System.IO.Compression;

namespace NX.Libs.CompressionLib.Services
{
    public class ZipCompressionService : ICompressionService
    {
        public byte[] Compress(byte[] data)
        {
            using MemoryStream memoryStream = new();
            using (ZipArchive zipStream = new(memoryStream, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry zipEntry = zipStream.CreateEntry("compressedFile");
                using Stream zipEntryStream = zipEntry.Open();
                zipEntryStream.Write(data, 0, data.Length);
            }
            return memoryStream.ToArray();
        }

        public byte[] Decompress(byte[] compressedData)
        {
            using MemoryStream inputStream = new(compressedData);
            using ZipArchive zipStream = new(inputStream, ZipArchiveMode.Read);
            ZipArchiveEntry? entry = zipStream.GetEntry("compressedFile");
            if (entry != null)
            {
                using Stream entryStream = entry.Open();
                using MemoryStream memoryStream = new();
                entryStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
            else
                return [];
        }
    }
}

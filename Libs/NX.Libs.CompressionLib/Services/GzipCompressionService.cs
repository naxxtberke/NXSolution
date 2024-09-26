using NX.Libs.CompressionLib.Interfaces;
using System.IO.Compression;

namespace NX.Libs.CompressionLib.Services
{
    public class GzipCompressionService : ICompressionService
    {
        public byte[] Compress(byte[] data)
        {
            using MemoryStream memoryStream = new();
            using (GZipStream gzipStream = new(memoryStream, CompressionMode.Compress))
            {
                gzipStream.Write(data, 0, data.Length);
            }
            return memoryStream.ToArray();
        }

        public byte[] Decompress(byte[] compressedData)
        {
            using MemoryStream inputStream = new(compressedData);
            using MemoryStream outputStream = new();
            using (GZipStream gzipStream = new(inputStream, CompressionMode.Decompress))
            {
                gzipStream.CopyTo(outputStream);
            }
            return outputStream.ToArray();
        }
    }
}

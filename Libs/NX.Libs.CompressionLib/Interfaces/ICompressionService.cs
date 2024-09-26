namespace NX.Libs.CompressionLib.Interfaces
{
    public interface ICompressionService
    {
        byte[] Compress(byte[] data);
        byte[] Decompress(byte[] compressedData);
    }
}

using System.Text;

namespace NX.Libs.CoreLib.Extensions
{
    public static class ByteExtensions
    {
        public static byte[] GetByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
    }
}

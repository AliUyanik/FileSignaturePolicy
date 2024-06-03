using System.IO;

namespace FileSignaturePolicy.Base
{
    internal static class StreamHelper
    {
        public static byte[] GetBytes(Stream stream, int offset, int limit, int buffersize)
        {
            byte[] buffer = new byte[buffersize];
            stream.Read(buffer, offset, limit);
            stream.Seek(0, SeekOrigin.Begin);
            return buffer;
        }
    }
}

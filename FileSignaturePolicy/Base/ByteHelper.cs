using System;

namespace FileSignaturePolicy.Base
{
    internal static class ByteHelper
    {
        public static byte[] Copy(byte[] source, int offset, int limit, int buffersize)
        {
            byte[] buffer = new byte[buffersize];
            Array.Copy(source, offset, buffer, 0, limit);
            return buffer;
        }
    }
}
